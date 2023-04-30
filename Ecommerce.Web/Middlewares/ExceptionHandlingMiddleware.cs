using System.Net;
using System.Text.Json;
using Ecommerce.Web.ResponseModels;

namespace Ecommerce.Web.Middlewares;

public class MyExceptionHandlingMiddleware
{
    private readonly RequestDelegate _delegate;
    private readonly Serilog.ILogger _logger;

    public MyExceptionHandlingMiddleware(RequestDelegate @delegate, Serilog.ILogger logger)
    {
        //'@' prefix becuase the word 'delegate' is from System namespace keywords but i insist in using the meaninigful name of the parametar
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

        context.Response.ContentType = "application/json";

        var response = context.Response;

        var errorResponse = new ErrorResponse
        {
            Success = false
        };


        switch (exception)
        {
            //here to add the exception cases that will be exist in the project .. include the custom exception that might be created
            default:

                response.StatusCode = (int)HttpStatusCode.InternalServerError;

                if (exception.Message == null || exception.Message.Length >= 65)
                    errorResponse.Message = "Internal server errors. check logs!";
                else
                    errorResponse.Message = exception.Message;

                _logger.Error($"Something went wrong | {exception}");
                break;
        }

        var result = JsonSerializer.Serialize(errorResponse);

        await context.Response.WriteAsync(result);
    }
}