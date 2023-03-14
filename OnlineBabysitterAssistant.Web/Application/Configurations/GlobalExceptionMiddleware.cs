using System.Net;
using Newtonsoft.Json;
using OnlineBabysitterAssistant.Domain.Exceptions;
using OnlineBabysitterAssistant.Domain.Exceptions.Custom;

namespace OnlineBabysitterAssistant.Web.Application.Configurations;

public class GlobalExceptionMiddleware
{
    private readonly RequestDelegate _next;

    public GlobalExceptionMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception e)
        {
            await HandleExceptionAsync(context, e);
        }
    }

    private static Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        ErrorResponseModel errorResponseModel = new ErrorResponseModel()
        {
            Message = exception.Message,
            StackTrace = exception.StackTrace
        };
        
        switch (exception)
        {
            case UserNotFoundException u:
                errorResponseModel.StatusCode = HttpStatusCode.Forbidden;
                break;
            default:
                errorResponseModel.StatusCode = HttpStatusCode.InternalServerError;
                break;
        }

        var messageResponse = JsonConvert.SerializeObject(errorResponseModel.Message);
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)errorResponseModel.StatusCode;

        return context.Response.WriteAsync(messageResponse);
    }
}