
using MessengerApi.Application.Common.Interfaces;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.DependencyInjection.Hubs;
using Microsoft.Extensions.DependencyInjection.Messages.Queries.GetMessages;

namespace Microsoft.Extensions.DependencyInjection.Services;


public class SignalRNotificationService : IMessageNotifier
{
    private readonly IHubContext<ChatHub> _hubContext;

    public SignalRNotificationService(IHubContext<ChatHub> hubContext)
    {
        _hubContext = hubContext;
    }

    public async Task SendNotificationToAllAsync(string message)
    {
        await _hubContext.Clients.All.SendAsync("ReceiveNotification", message);
    }

    public Task SentMessageToUser(Guid chatId, MessageDto message)
    {
        return _hubContext.Clients.Group(chatId.ToString())
            .SendAsync("MessageReceived", message);
    }

   

    
}
