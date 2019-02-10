using Domain.ValueObjects;
using Microsoft.AspNetCore.Http;
using Serilog;
using System;
using System.Net;
using System.Threading.Tasks;

namespace hosting.MiddleWares
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly Serilog.ILogger _logger;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _logger = Log.Logger.ForContext<ExceptionMiddleware>();
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                _logger.Error("Something went wrong: {@Exception}", ex);
                await HandleExceptionAsync(httpContext, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            return context.Response.WriteAsync(new ErrorDetails
            {
                StatusCode = context.Response.StatusCode,
                Message = "Internal Server Error."
            }.ToString());
        }
    }
}