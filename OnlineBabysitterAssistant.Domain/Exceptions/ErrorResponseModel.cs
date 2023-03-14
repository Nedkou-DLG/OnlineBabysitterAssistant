using System.Net;

namespace OnlineBabysitterAssistant.Domain.Exceptions;

public class ErrorResponseModel
{
    public HttpStatusCode StatusCode { get; set; }
    public string Message { get; set; }
    public string StackTrace { get; set; }
}