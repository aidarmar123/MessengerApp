using MessengerApi.Application.Common.Interfaces;
using MessengerApi.Domain.Entities;

namespace Microsoft.Extensions.DependencyInjection.Chats.Command.CreateChat;

public class CreateChatCommandHandler: IRequestHandler<CreateChatCommand, Guid>
{
    private readonly IApplicationDbContext _context;

    public CreateChatCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Guid> Handle(CreateChatCommand request, CancellationToken cancellationToken)
    {
        var chat = new Chat()
        {
            Title = request.Title,
            Type = request.Type,
        };
        
        _context.Chats.Add(chat);
        
        await _context.SaveChangesAsync(cancellationToken);
        return chat.Id;
    }
}
