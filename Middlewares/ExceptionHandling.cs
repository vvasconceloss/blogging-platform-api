using System.Net;
using System.Text.Json;
using bloggin_plataform_api.Exceptions;

namespace bloggin_plataform_api.Middlewares
{
    public class ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
    {
        private readonly RequestDelegate _next = next;
        private readonly ILogger<ExceptionHandlingMiddleware> _logger = logger;

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, "Unhandled exception caught by middleware");
                context.Response.ContentType = "application/json";

                var (statusCode, title) = MapException(exception);

                context.Response.StatusCode = (int)statusCode;

                var problemPayload = new
                {
                    title,
                    detail = exception.Message,
                    status = context.Response.StatusCode,
                };

                var options = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
                var json = JsonSerializer.Serialize(problemPayload, options);

                await context.Response.WriteAsync(json);
            }
        }

        private static (HttpStatusCode statusCode, string title) MapException(Exception exception)
        {
            return exception switch
            {
                NotFoundException => (HttpStatusCode.NotFound, "Resource not found"),
                ValidationException => (HttpStatusCode.BadRequest, "Validation failed"),
                UnauthorizedAccessException => (HttpStatusCode.Unauthorized, "Unauthorized"),
                _ => (HttpStatusCode.InternalServerError, "An unexpected error occurred"),
            };
        }
    }
}