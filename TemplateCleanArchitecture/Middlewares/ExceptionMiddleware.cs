using Domain.Exceptions;

namespace Api.Middlewares;

public class ExceptionMiddleware
{
    private readonly RequestDelegate _next;

    public ExceptionMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(context, ex);
        }
    }

    private static async Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        context.Response.ContentType = "application/json";

        int statusCode;
        object response;

        if (exception is ApiException apiException)
        {
            statusCode = (int)apiException.ExceptionType;

            response = new
            {
                status = statusCode,
                code = apiException.ExceptionCode.ToString(),
                message = apiException.ErrorMessage,
                details = apiException.ErrorDetails,
                date = DateTime.UtcNow.ToString()
            };
        }
        else
        {
            statusCode = StatusCodes.Status500InternalServerError;

            response = new
            {
                status = statusCode,
                code = "UNEXPECTED_ERROR",
                message = "Ocurrió un error inesperado",
                details = exception.Message,
                date = DateTime.UtcNow.ToString()
            };
        }
        context.Response.StatusCode = statusCode;
        await context.Response.WriteAsJsonAsync(response);
    }
}

