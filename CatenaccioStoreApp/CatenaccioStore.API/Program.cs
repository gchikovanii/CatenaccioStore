using CatenaccioStore.API.Infrastructure.Extensions;
using CatenaccioStore.Application.Infrastruture.Extensions;
using CatenaccioStore.Domain.Entities.Users;
using CatenaccioStore.Persistence.DataContext;
using CatenaccioStore.Persistence.store;
using Microsoft.EntityFrameworkCore;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddServices();
builder.Services.AddJwt(builder.Configuration);
builder.Services.AddCloudinary(builder.Configuration);
#region AddFluentValidation
builder.Services.AddFluentValidation();
#endregion
#region Serilog
builder.Host.UseSerilog((context, conf) =>
conf.ReadFrom.Configuration(context.Configuration));
#endregion
#region Sql Connection
builder.Services.Configure<ConnectionStrings>(builder.Configuration.GetSection(nameof(ConnectionStrings)));
builder.Services.AddDbContext<ApplicationDbContext>(options =>
                                                  options.UseSqlServer(builder.Configuration.GetConnectionString(nameof(ConnectionStrings.DefaultConnectionString))), ServiceLifetime.Scoped);
#endregion
#region Add Ef
builder.Services.AddIdentity<AppUser, AppRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>();
#endregion
builder.Services.AddCors(options => options.AddPolicy("FrontEnd",policy =>
{
    policy.WithOrigins("http://localhost:4200").AllowAnyMethod().AllowAnyHeader().AllowAnyOrigin();
}));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseSerilogRequestLogging();
app.UseHttpsRedirection();
app.UseCulture();
app.UseGlobalExceptionHandler();
app.UseAuthentication();
app.UseAuthorization();
app.UseHttpsRedirection();
app.UseCors("FrontEnd");
app.MapControllers();

#region APP RUN
try
{
    app.Run();
}
catch (Exception ex)
{
    Log.Fatal("Host Crashed! Exception: " + ex);
}
#endregion
