namespace MessengerApi.Application.Messages.Command.SendMessage;

public record SendMessageCommand(Guid ChatId, Guid SenderId, string Content) : IRequest<Guid>;
