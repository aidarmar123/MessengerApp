namespace MessengerApi.Domain.Entities;

public class User:BaseAuditableEntity
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Displayname { get; set; } = string.Empty;
    public string Alice { get; set; } = string.Empty;
    
    public ICollection<ChatMember> Chats { get; set; } = new List<ChatMember>();
    public ICollection<Message> Messages { get; set; } = new List<Message>();
}
