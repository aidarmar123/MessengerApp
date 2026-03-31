using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MessengerApi.Application.Common.Interfaces;
using MessengerApi.Application.Messages.Dto;
using Microsoft.AspNetCore.SignalR;

namespace MessengerApi.Infrastructure.Notifications;
public class NotificationService : INotificationService
{
    private readonly IHubContext<ChatHub> _hubContext;

    public NotificationService(IHubContext<ChatHub> hubContext)
    {
        _hubContext = hubContext;
    }

    public async Task SendMessageAsync(Guid chatId, MessageDto message)
    {
        await _hubContext.Clients.Group(chatId.ToString())
            .SendAsync("ReceiveMessage", message);
    }
}
