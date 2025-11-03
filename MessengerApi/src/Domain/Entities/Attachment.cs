namespace MessengerApi.Domain.Entities;

public class Attachment : BaseAuditableEntity
{
    public Guid MessageId { get; set; }
    public Message Message { get; set; } = null!;

    public string FileName { get; set; } = string.Empty;
    public long FileSize { get; set; }
    public AttachmentType Type { get; set; }

    public AttachmentMetadata Metadata { get; set; } = new();
}
