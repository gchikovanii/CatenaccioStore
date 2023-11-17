using CatenaccioStore.Application.Services.Cloudinaries.Abstraction;
using CatenaccioStore.Application.Services.Cloudinaries.Implementation;
using CatenaccioStore.Application.Services.Configurations;

namespace CatenaccioStore.API.Infrastructure.Extensions
{
    public static class CloudinaryExtension 
    {
        public static void AddCloudinary(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<CloudinarySetting>(configuration.GetSection("CloudinarySettings"));
            services.AddScoped<ICloudinaryService, CloudinaryService>();
        }
    }
}
