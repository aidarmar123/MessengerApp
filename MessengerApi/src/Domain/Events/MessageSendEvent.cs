namespace MessengerApi.Domain.Events;

public class MessageSendEvent:BaseEvent
{
    public MessageSendEvent(Message message)
    {
        this.Message = message;
    }
    public Message Message { get; }
}
