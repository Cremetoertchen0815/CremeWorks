namespace CremeWorks.Backend;

public class RequestLoggingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<RequestLoggingMiddleware> _logger;

    public RequestLoggingMiddleware(RequestDelegate next, ILogger<RequestLoggingMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task Invoke(HttpContext context)
    {
        // Log the request information
        _logger.LogInformation("HTTP {Method} {Path} received", context.Request.Method, context.Request.Path);

        // Call the next middleware in the pipeline
        await _next(context);

        // Log the response status code after the request has been handled
        _logger.LogInformation("Response {StatusCode} for {Path}", context.Response.StatusCode, context.Request.Path);
    }
}