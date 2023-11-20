using CatenaccioStore.API.Infrastructure.Middlewares;

namespace CatenaccioStore.API.Infrastructure.Extensions
{
    public static class GlobalExceptionHandlingMiddleware
    {
        public static IApplicationBuilder UseGlobalExceptionHandler(this IApplicationBuilder app)
        {
            return app.UseMiddleware<ExceptionHandlingMiddleware>();
        }
    }
}
