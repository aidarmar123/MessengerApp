using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessengerApi.Application.Messages.Dto;
public class MessageDto
{
    public Guid Id { get;  set; }
    public string Content { get; set; } = string.Empty;
    public string SenderName { get;  set; } = string.Empty;
    public DateTime SendAt { get; set; }
    public List<string> Attachments { get;  set; } = new List<string>();
}
