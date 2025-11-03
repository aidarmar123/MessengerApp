using MessengerApi.Domain.Constants;

namespace MessengerApi.Domain.Exceptions;

public class MessageTooLongException:Exception
{
    public MessageTooLongException(int length):base($"Message too long: {length}, correct long not more {MessageLimits.MaxMessageLength}"){}
}
