using CatenaccioStore.API.Infrastructure.Middlewares;

namespace CatenaccioStore.API.Infrastructure.Extensions
{
    public static class CultureMiddlewareExtension
    {
        public static IApplicationBuilder UseRequestCulture(this IApplicationBuilder app) 
        {
            return app.UseMiddleware<CultureMiddleware>();
        }
    }
}
