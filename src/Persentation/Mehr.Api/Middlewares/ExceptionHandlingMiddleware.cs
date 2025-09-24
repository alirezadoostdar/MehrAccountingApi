using Mehr.Domain;
using Mehr.SharedKernel;
using Microsoft.AspNetCore.Http;
using System.Net;
using System.Text.Json;

namespace Mehr.Api.Middlewares;

public class ExceptionHandlingMiddleware
{
    private readonly RequestDelegate _next;
    public readonly ILogger<ExceptionHandlingMiddleware> _logger;

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
        catch (BusinessException ex) // custom domain/application exception
        {
            _logger.LogError(ex, "Unhandled exception occurred.");
            //await HandleExceptionAsync(context, ex, HttpStatusCode.InternalServerError);

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            var json = JsonSerializer.Serialize(ex.Result);
            await context.Response.WriteAsync(json);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Unhandled exception occurred.");
            //await HandleExceptionAsync(context, ex, HttpStatusCode.InternalServerError);

            var result = Result.Failure(Error.Problem("500", ex.Message));

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            var json = JsonSerializer.Serialize(result);
            await context.Response.WriteAsync(json);
        }
    }

    private static Task HandleExceptionAsync(HttpContext context, Exception ex, HttpStatusCode code)
    {
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)code;

        var result = JsonSerializer.Serialize(new { error = ex.Message });
        return context.Response.WriteAsync(result);
    }
}
