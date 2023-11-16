using CatenaccioStore.Application.Infrastruture.JWT;
using CatenaccioStore.Application.Services.Abstraction;
using CatenaccioStore.Application.Services.Implementation;
using CatenaccioStore.Infrastructure.Repositories.Abstraction;
using CatenaccioStore.Infrastructure.Repositories.Implementation;
using CatenaccioStore.Infrastructure.Units;
using Microsoft.Extensions.DependencyInjection;

namespace CatenaccioStore.Application.Infrastruture.Extensions
{
    public static class Extension
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}
