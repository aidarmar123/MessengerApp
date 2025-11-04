using MessengerApi.Application.Common.Interfaces;
using MessengerApi.Domain.Entities;

namespace Microsoft.Extensions.DependencyInjection.Messages.Queries.GetMessages;

public class GetMessagesQueryHandler:IRequestHandler<GetMessagesQuery, List<MessageDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;
    public GetMessagesQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<MessageDto>> Handle(GetMessagesQuery request, CancellationToken cancellationToken)
    {
        return await _context.Messages
            .Where(m => m.ChatId == request.chatId)
            .OrderBy(m=>m.SendAt)
            .ProjectTo<MessageDto>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);
    }
}
