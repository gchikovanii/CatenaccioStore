using CatenaccioStore.API.Infrastructure.Middlewares;

namespace CatenaccioStore.API.Infrastructure.Extensions
{
    public static class CultureMiddlewareExtension
    {
        public static IApplicationBuilder UseCulture(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<CultureConfigMiddleware>();
        }
    }
}
