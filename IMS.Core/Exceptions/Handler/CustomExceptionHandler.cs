using FluentValidation;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace IMS.Core.Exceptions.Handler;

public class CustomExceptionHandler(
    ILogger<CustomExceptionHandler> logger,
    IWebHostEnvironment environment
) : IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(
        HttpContext httpContext,
        Exception exception,
        CancellationToken cancellationToken
    )
    {
        logger.LogError("Exception: {0} occurred on: {1}", exception.Message, DateTime.UtcNow);

        string detail,
            title;
        int statusCode;
        switch (exception)
        {
            case ValidationException:
            case BadRequestException:
                detail = exception.Message;
                title = exception.GetType().Name;
                statusCode = StatusCodes.Status400BadRequest;
                break;
            case NotFoundException:
                detail = exception.Message;
                title = exception.GetType().Name;
                statusCode = StatusCodes.Status404NotFound;
                break;
            default:
                detail = environment.IsDevelopment()
                    ? exception.Message
                    : "An error has occurred, please contact the administrator";
                title = exception.GetType().Name;
                statusCode = StatusCodes.Status500InternalServerError;
                break;
        }

        httpContext.Response.StatusCode = statusCode;

        var problemDetails = new ProblemDetails
        {
            Title = title,
            Detail = detail,
            Status = statusCode,
            Instance = httpContext.Request.Path,
        };

        problemDetails.Extensions.Add("traceId", httpContext.TraceIdentifier);

        if (exception is ValidationException validationException)
        {
            problemDetails.Extensions.Add("ValidationErrors", validationException.Errors);
        }

        await httpContext.Response.WriteAsJsonAsync(problemDetails, cancellationToken);

        return true;
    }
}
