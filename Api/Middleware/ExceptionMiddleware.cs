using System.Net;
using Api.Models;
using Application.Exceptions;
using Newtonsoft.Json;

namespace Api.Middleware;

public class ExceptionMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ExceptionMiddleware> _logger;

    public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext httpContext)
    {
        try
        {
            // If there is no exception, then the request is passed to the next middleware
            await _next(httpContext);
        }
        catch (Exception ex)
        {
            // If there is an exception, then the request is handled by this middleware
            await HandleExceptionAsync(httpContext, ex);
        }
    }

    private async Task HandleExceptionAsync(HttpContext httpContext, Exception ex)
    {
        HttpStatusCode statusCode;
        CustomProblemDetails problem;

        switch (ex)
        {
            /*
             * If the exception is of type BadRequestException, then the status code is 400
             * and the validation errors are returned in the response body
            */
            case BadRequestException badRequestException:
                statusCode = HttpStatusCode.BadRequest;
                problem = new CustomProblemDetails
                {
                    Title = badRequestException.Message,
                    Status = (int)statusCode,
                    Type = nameof(BadRequestException),
                    Errors = badRequestException.ValidationErrors
                };
                break;
            /*
             * If the exception is of type NotFoundException, then the status code is 404
             * and the exception message is returned in the response body
            */
            case NotFoundException notFound:
                statusCode = HttpStatusCode.NotFound;
                problem = new CustomProblemDetails
                {
                    Title = notFound.Message,
                    Status = (int)statusCode,
                    Type = nameof(NotFoundException),
                };
                break;
            /*
             * If the exception is not specific, then the status code is 500
             * and the stack trace and exception is logged 
            */
            default:
                statusCode = HttpStatusCode.InternalServerError;
                problem = new CustomProblemDetails
                {
                    Title = "An internal server error occurred",
                    Status = (int)statusCode,
                    Type = nameof(HttpStatusCode.InternalServerError),
                };
                
                var logMessage = $"Message: {ex.Message}\nStackTrace: {ex.StackTrace}";
                _logger.LogError(logMessage);
                break;
        }

        httpContext.Response.StatusCode = (int)statusCode;
        await httpContext.Response.WriteAsJsonAsync(problem);
    }
}