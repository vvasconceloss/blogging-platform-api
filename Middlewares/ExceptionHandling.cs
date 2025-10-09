using System.Net;
using System.Text.Json;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
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
                context.Response.ContentType = "application/json";

                var (statusCode, type, title) = MapException(exception);

                context.Response.StatusCode = (int)statusCode;

                var problemDetails = new ProblemDetails
                {
                    Title = title,
                    Detail = exception.Message,
                    Instance = context.Request.Path,
                    Status = context.Response.StatusCode
                };

                problemDetails.Extensions["traceId"] = context.TraceIdentifier ?? Activity.Current?.Id;

                if (exception is ValidationException validationException && validationException.Errors?.Any() == true)
                    problemDetails.Extensions["errors"] = validationException.Errors;

                switch (exception)
                {
                    case ValidationException:
                        _logger.LogWarning("Validation Error: {Message}", exception.Message);
                        break;
                    case UnauthorizedAccessException:
                        _logger.LogWarning("Unauthorized Error: {Message}", exception.Message);
                        break;
                    case NotFoundException:
                        _logger.LogWarning("Not Found Error: {Message}", exception.Message);
                        break;
                    default:
                        _logger.LogError(exception, "Unhandled Exception");
                        break;
                }

                var options = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
                var json = JsonSerializer.Serialize(problemDetails, options);

                await context.Response.WriteAsync(json);
            }
        }

        private static (HttpStatusCode statusCode, string type, string title) MapException(Exception exception)
        {
            return exception switch
            {
                NotFoundException => (HttpStatusCode.NotFound, "NotFound", "Failed to find this resource"),
                ValidationException => (HttpStatusCode.BadRequest, "BadRequest", "There was an error in validating the data."),
                UnauthorizedAccessException => (HttpStatusCode.Unauthorized, "Unauthorized", "Unauthorized access to this resource"),
                _ => (HttpStatusCode.InternalServerError, "InternalServer", "An unexpected error has occurred"),
            };
        }
    }
}