namespace MessengerApi.Domain.Entities;

public class Chat:BaseAuditableEntity
{
    public string Title { get; set; } = string.Empty;
    public ChatType Type { get; set; }
    public ICollection<User> Participants { get; set; } = new List<User>();
    public ICollection<Message> Messages { get; set; } = new List<Message>();
}
