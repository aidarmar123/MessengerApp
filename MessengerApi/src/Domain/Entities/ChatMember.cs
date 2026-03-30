using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessengerApi.Domain.Entities;


public class ChatMember : BaseAuditableEntity
{
    public Guid ChatId { get; set; }
    public Chat Chat { get; set; } = null!;

    public Guid UserId { get; set; }
    public User User { get; set; } = null!;

    public ChatRole Role { get; set; } = ChatRole.Member;

    // Полезно для логики "непрочитанных"
    public DateTime? LastReadAt { get; set; }
}
