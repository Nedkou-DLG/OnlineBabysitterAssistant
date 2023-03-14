namespace OnlineBabysitterAssistant.Domain.Exceptions.Custom;

public class UserNotFoundException : Exception
{
    public UserNotFoundException(string message) : base(message)
    {
    }
}