using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MessengerApi.Domain.Enums;

namespace MessengerApi.Application.Chats.Dto;
public class ChatDto
{
    public Guid Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public ChatType Type { get; set; }
    public string? LastMessageContent { get; set; }
    public DateTime? LastMessageAt { get; set; }
    public int UnreadCount { get; set; }
}
