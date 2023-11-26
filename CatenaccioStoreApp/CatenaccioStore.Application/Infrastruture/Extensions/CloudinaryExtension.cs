using CatenaccioStore.Application.Services.Cloudinaries.Abstraction;
using CatenaccioStore.Application.Services.Cloudinaries.Implementation;
using CatenaccioStore.Application.Services.Configurations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CatenaccioStore.Application.Infrastruture.Extensions
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
