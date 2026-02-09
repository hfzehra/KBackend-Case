using Microsoft.AspNetCore.Http;
using System.Net;
using System.Text.Json;

namespace Core.Utilities.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
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
                await HandleExceptionAsync(httpContext, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)GetStatusCode(exception);

            var response = new ErrorDetails
            {
                StatusCode = context.Response.StatusCode,
                Message = exception.Message,
                Detail = GetExceptionDetail(exception)
            };

            return context.Response.WriteAsync(JsonSerializer.Serialize(response, new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            }));
        }

        private static HttpStatusCode GetStatusCode(Exception exception)
        {
            return exception switch
            {
                ArgumentNullException => HttpStatusCode.BadRequest,
                ArgumentException => HttpStatusCode.BadRequest,
                KeyNotFoundException => HttpStatusCode.NotFound,
                UnauthorizedAccessException => HttpStatusCode.Unauthorized,
                InvalidOperationException => HttpStatusCode.BadRequest,
                _ => HttpStatusCode.InternalServerError
            };
        }

        private static string GetExceptionDetail(Exception exception)
        {
#if DEBUG
            return exception.StackTrace ?? string.Empty;
#else
            return string.Empty;
#endif
        }
    }

    public class ErrorDetails
    {
        public int StatusCode { get; set; }
        public string Message { get; set; } = string.Empty;
        public string Detail { get; set; } = string.Empty;
    }
}
