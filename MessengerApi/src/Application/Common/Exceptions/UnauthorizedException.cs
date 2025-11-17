namespace MessengerApi.Application.Common.Exceptions;

public class UnauthorizedException: Exception
{
    public UnauthorizedException(string error)
    {
        Error = error;
    }

    public string Error { get; }
    
}
