using MessengerApi.Domain.Enums;

namespace Microsoft.Extensions.DependencyInjection.Chats.Command.CreateChat;

public record CreateChatCommand(string Title, ChatType Type):IRequest<Guid>;
