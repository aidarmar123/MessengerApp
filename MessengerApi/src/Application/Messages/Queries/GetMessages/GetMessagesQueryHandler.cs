using MessengerApi.Application.Common.Interfaces;
using MessengerApi.Domain.Entities;

namespace Microsoft.Extensions.DependencyInjection.Messages.Queries.GetMessages;

public class GetMessagesQueryHandler:IRequestHandler<GetMessagesQuery, List<Message>>
{
    private readonly IApplicationDbContext _context;

    public GetMessagesQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<Message>> Handle(GetMessagesQuery request, CancellationToken cancellationToken)
    {
        return await _context.Messages
            .Where(m => m.ChatId == request.chatId)
            .OrderBy(m=>m.SendAt)
            .ToListAsync(cancellationToken);
    }
}
