namespace MessengerApi.Domain.Entities;

public class Chat:BaseAuditableEntity
{
    public string Title { get; set; } = string.Empty;
    public ChatType Type { get; set; }
    public ICollection<ChatMember> Members { get; set; } = new List<ChatMember>();
    public ICollection<Message> Messages { get; set; } = new List<Message>();
}
