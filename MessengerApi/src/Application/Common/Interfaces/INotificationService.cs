using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MessengerApi.Application.Messages.Dto;

namespace MessengerApi.Application.Common.Interfaces;
public interface INotificationService
{
    Task SendMessageAsync(Guid chatId, MessageDto message);
}
