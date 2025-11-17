using Microsoft.Extensions.DependencyInjection.Messages.Queries.GetMessages;

namespace MessengerApi.Application.Common.Interfaces;

public interface IMessageNotifier
{
    Task SendNotificationToAllAsync(MessageDto message);
    Task SentMessageToUser(Guid chatId, MessageDto message);
}
