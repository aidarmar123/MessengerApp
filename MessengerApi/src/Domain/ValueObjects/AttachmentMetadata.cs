namespace MessengerApi.Domain.ValueObjects;

public class AttachmentMetadata
{
    public string MimeType { get; set; } = string.Empty;
    public int Width { get; set; }
    public int Height { get; set; }
}
