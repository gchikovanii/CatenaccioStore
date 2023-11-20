using Microsoft.AspNetCore.Http;
using System.Globalization;

namespace CatenaccioStore.API.Infrastructure.Middlewares
{
    public class CultureMiddleware
    {
        private readonly RequestDelegate _next;

        public CultureMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public void Invoke(HttpContext context)
        {
            var cultureName = "en-US";
            var queryCulture = context.Request.Headers["Accept-Language"].ToString();
            if (!String.IsNullOrWhiteSpace(queryCulture))
            {
                cultureName = queryCulture.Split(',')[0];
            }
            var culture = new CultureInfo(cultureName);
            CultureInfo.CurrentCulture = culture;
            CultureInfo.CurrentUICulture = culture;
            _next(context);
        }
    }
}
