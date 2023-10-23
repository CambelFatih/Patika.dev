using System;
using System.Diagnostics;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using WebApi.Services;

namespace WebApi.Middleware
{
    /// <summary>
    /// Middleware for handling custom exceptions in the application.
    /// </summary>
    public class CustomExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILoggerService _loggerService;

        /// <summary>
        /// Constructor for CustomExceptionMiddleware.
        /// </summary>
        /// <param name="next">The next middleware in the pipeline.</param>
        /// <param name="loggerService">The logger service for logging exceptions.</param>
        public CustomExceptionMiddleware(RequestDelegate next, ILoggerService loggerService)
        {
            _next = next;
            _loggerService = loggerService;
        }

        public async Task Invoke(HttpContext context)
        {
            var watch = Stopwatch.StartNew();
            try
            {
                string message = "[Request]  HTTP " + context.Request.Method + " - " + context.Request.Path;
                _loggerService.Write(message);
                await _next(context);
                watch.Stop();
                message = "[Response] HTTP " + context.Request.Method + " - " + context.Request.Path + " responded " + context.Response.StatusCode + " in " + watch.Elapsed.TotalMilliseconds + "ms";
                _loggerService.Write(message);
            }
            catch (Exception ex)
            {
                watch.Stop();
                await HandleException(context, ex, watch);
            }
        }

        private Task HandleException(HttpContext context, Exception ex, Stopwatch watch)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            string message = "[Error]    HTTP  " + context.Request.Method + " - " + context.Response.StatusCode + " Error Message " + ex.Message + " in " + watch.Elapsed.TotalMilliseconds + " ms ";
            _loggerService.Write(message);
            var result = JsonConvert.SerializeObject(new { error = ex.Message }, Formatting.None);
            return context.Response.WriteAsync(result);
        }
    }

    /// <summary>
    /// Extension method for using the CustomExceptionMiddleware in the application.
    /// </summary>
    public static class CustomExceptionMiddlewareExtension
    {
        /// <summary>
        /// Use the CustomExceptionMiddleware in the application's middleware pipeline.
        /// </summary>
        /// <param name="builder">The application builder.</param>
        /// <returns>The application builder with the CustomExceptionMiddleware added.</returns>
        public static IApplicationBuilder UseCustomExceptionMiddle(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<CustomExceptionMiddleware>();
        }
    }
}
