using System.Net;
using System.Text.Json;
using Ecommerce.Web.ResponseModels;

namespace Ecommerce.Web.Middlewares;

public class MyExceptionHandlingMiddleware
{
    private readonly RequestDelegate _delegate;
    private readonly ILogger _logger;

    public MyExceptionHandlingMiddleware(RequestDelegate @delegate, ILogger logger)
    {
        _delegate = @delegate;
        _logger = logger;
    }
    public async Task InvokeAsync(HttpContext httpContext)
    {
        try
        {
            await _delegate(httpContext);
        }
        catch (Exception ex)
        {

            await HandleExceptionAsync(httpContext, ex);
        }

    }

    private async Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        var currentUserName = context.User.Claims.Where(x => x.Type == "emailaddress").FirstOrDefault()?.Value ?? String.Empty;

        context.Response.ContentType = "application/json";

        var response = context.Response;

        var errorResponse = new ErrorResponse
        {
            Success = false
        };

        if (exception.Message.Contains("Invalid token"))
        {
            response.StatusCode = (int)HttpStatusCode.Forbidden;
            errorResponse.Message = exception.Message;
            await context.Response.WriteAsync(JsonSerializer.Serialize(errorResponse));
        }

        switch (exception)
        {
            //here to add the exception cases that will be exist in the project .. include the custom exception that might be created
            default:

                response.StatusCode = (int)HttpStatusCode.InternalServerError;

                if (exception.Message == null || exception.Message.Length >= 65)
                    errorResponse.Message = "Internal Server errors. Check Logs!";
                else
                    errorResponse.Message = exception.Message;

                _logger.LogError($"{currentUserName} Something went wrong | {exception}");
                break;
        }

        var result = JsonSerializer.Serialize(errorResponse);

        await context.Response.WriteAsync(result);
    }
}