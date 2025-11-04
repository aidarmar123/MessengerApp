using System.Net;
using System.Text.Json;
using MessengerApi.Application.Common.Exceptions;

namespace Microsoft.Extensions.DependencyInjection.Middleware;

public class ExceptionHandlingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ExceptionHandlingMiddleware> _logger;

    public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(context, ex, _logger);
        }
    }

    private static async Task HandleExceptionAsync(HttpContext context, Exception exception, ILogger logger)
    {
        context.Response.ContentType = "application/json";
        var response = context.Response;
        var result = string.Empty;

        switch (exception)
        {
            case ValidationException validationEx:
                response.StatusCode = (int)HttpStatusCode.BadRequest;
                result = JsonSerializer.Serialize(new
                {
                    message = "Validation failed",
                    errors = validationEx.Errors.Select(e => e.Value)
                });
                break;

            default:
                response.StatusCode = (int)HttpStatusCode.InternalServerError;
                result = JsonSerializer.Serialize(new
                {
                    message = "An unexpected error occurred",
                    error = exception.Message
                });
                break;
        }

        logger.LogError(exception, "An error occurred: {Message}", exception.Message);
        await context.Response.WriteAsync(result);
    }
}
