using CatenaccioStore.Application.Infrastruture.JWT;
using CatenaccioStore.Application.Services.Accounts.Abstraction;
using CatenaccioStore.Application.Services.Accounts.Implementation;
using CatenaccioStore.Application.Services.Products.Abstraction;
using CatenaccioStore.Application.Services.Products.Implementation;
using CatenaccioStore.Infrastructure.Repositories.Abstraction;
using CatenaccioStore.Infrastructure.Repositories.Abstraction.Products;
using CatenaccioStore.Infrastructure.Repositories.Implementation;
using CatenaccioStore.Infrastructure.Repositories.Implementation.Products;
using CatenaccioStore.Infrastructure.Units;
using Microsoft.Extensions.DependencyInjection;

namespace CatenaccioStore.Application.Infrastruture.Extensions
{
    public static class ServiceInjectionExtension
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IProductImageRepository, ProductImageRepository>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IProductImageService, ProductImageService>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}
