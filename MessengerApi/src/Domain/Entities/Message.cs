namespace MessengerApi.Domain.Entities;

public class Message: BaseAuditableEntity
{
    public Guid ChatId { get; set; }
    public Chat Chat { get; set; } = null!;

    public Guid SenderId { get; set; }
    public User Sender { get; set; } = null!;

    public DateTime SendAt { get; set; } = DateTime.UtcNow;
    public string Content { get; set; } = string.Empty;

    public ICollection<Attachment> Attachments { get; set; } = new List<Attachment>();
}
