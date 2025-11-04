using MessengerApi.Domain.Entities;
using Microsoft.Extensions.DependencyInjection.Messages.Queries.GetMessages;

namespace MessengerApi.Application.Common.Mappings;

public class MappingProfile:Profile
{
    public MappingProfile()
    {
        CreateMap<Message, MessageDto>();
        CreateMap<Attachment, AttachmentDto>();
    }
}
