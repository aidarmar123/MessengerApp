using MessengerApi.Domain.Enums;

namespace MessengerApi.Application.Chats.Commands.CreateChat;

public record CreateChatCommand(string Title, ChatType Type):IRequest<Guid>;
