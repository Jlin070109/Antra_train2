using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace MovieShop.Utilities.CustomMiddlewares
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class LoggingExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;

        

        public LoggingExceptionMiddleware(RequestDelegate next, ILoggerFactory loggerFactory)
        {
            _next = next;
            _logger = loggerFactory.CreateLogger<LoggingExceptionMiddleware>();
        }

        public async Task Invoke(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex) 
            {
                CatchException(ex, httpContext);
            }
        }

        private void CatchException(Exception ex, HttpContext httpContext)
        {
            _logger.LogError(ex.Message);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class LoggingMiddlewareExtensions
    {
        public static IApplicationBuilder UseLoggingExceptionMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<LoggingExceptionMiddleware>();
        }
    }
}
