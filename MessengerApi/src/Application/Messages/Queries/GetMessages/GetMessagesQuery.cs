using MessengerApi.Domain.Entities;

namespace Microsoft.Extensions.DependencyInjection.Messages.Queries.GetMessages;

public record GetMessagesQuery(Guid chatId):IRequest<List<Message>>;
