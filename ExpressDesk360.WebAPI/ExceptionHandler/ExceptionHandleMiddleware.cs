using Microsoft.AspNetCore.Diagnostics;

namespace ExpressDesk360.WebAPI.ExceptionHandler;

public class ExceptionHandleMiddleware : IExceptionHandler
{
    private readonly ILogger<ExceptionHandleMiddleware> _logger;
    public ExceptionHandleMiddleware(ILogger<ExceptionHandleMiddleware> logger) => _logger = logger;


    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
    {
        var traceId = httpContext.TraceIdentifier;

        // A rejected dynamic filter/sort field is bad input, not a server fault. Reporting it as
        // 500 both misleads the caller and fills the error log with ordinary client mistakes.
        bool isBadRequest = exception is ArgumentException;

        if (isBadRequest)
            _logger.LogWarning("A request was rejected as invalid. TraceId: {TraceId}, Message: {Message}", traceId, exception.Message);
        else
            _logger.LogError(exception, "An error occurred during the process. TraceId: {TraceId}, Message: {Message}, InnerException: {InnerException}", traceId, exception.Message, exception.InnerException?.Message ?? string.Empty);

        int statusCode = isBadRequest ? StatusCodes.Status400BadRequest : StatusCodes.Status500InternalServerError;

        httpContext.Response.ContentType = "application/problem+json";
        httpContext.Response.StatusCode = statusCode;
        await httpContext.Response.WriteAsJsonAsync(new Microsoft.AspNetCore.Mvc.ProblemDetails()
        {
            Status = statusCode,
            Type = isBadRequest
                ? "http://ExpressDesk360.com/problems/BadRequest"
                : "http://ExpressDesk360.com/problems/InternalServerError",
            // Safe to surface: ArgumentException here only ever reports a rejected field name.
            Title = isBadRequest ? exception.Message : "An error occurred",
            Extensions =
            {
                ["traceId"] = traceId
            }
        });
        return true;
    }
}