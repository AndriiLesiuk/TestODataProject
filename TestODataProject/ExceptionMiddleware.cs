using System.Net;
using System.Text.Json;

namespace TestODataProject
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate next;
        private readonly ILogger<ExceptionMiddleware> _logger;

        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
        {
            this.next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await next(context);
            }
            catch (CustomException exception)
            {
                _logger.LogError($"{exception.Message}\n{exception}");
                await HandleCustomExceptionAsync(context, exception);
            }
            catch (Exception exception)
            {
                var exMessage = exception.InnerException != null ? exception.InnerException.Message : exception.Message;
                _logger.LogError($"{exMessage}\n{exception}");
                await HandleExceptionAsync(context, exception);
            }
        }

        private static async Task HandleCustomExceptionAsync(HttpContext context, CustomException exception)
        {
            var errorResponse = new
            {
                error = new
                {
                    code = (int)exception.StatusCode,
                    message = exception.ErrorMessage
                }
            };

            await WriteErrorResponseAsync(context, exception.StatusCode, errorResponse);
        }

        private static async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            var errorResponse = new
            {
                error = new
                {
                    code = (int)HttpStatusCode.InternalServerError,
                    message = exception.InnerException != null ? exception.InnerException.Message : exception.Message
                }
            };

            await WriteErrorResponseAsync(context, HttpStatusCode.InternalServerError, errorResponse);
        }

        private static async Task WriteErrorResponseAsync(HttpContext context, HttpStatusCode statusCode, object errorResponse)
        {
            var options = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
            var errorResponseJson = JsonSerializer.Serialize(errorResponse, options);

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)statusCode;

            await context.Response.WriteAsync(errorResponseJson);
        }
    }
}
