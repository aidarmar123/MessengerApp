using MessengerApi.Application.Common.Interfaces;
using MessengerApi.Domain.Entities;

namespace MessengerApi.Application.Messages.Command.SendMessage;

public class SendMessageCommandHandler:IRequestHandler<SendMessageCommand, Guid>
{
    private readonly IApplicationDbContext _context;

    public SendMessageCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }
    
    public async Task<Guid> Handle(SendMessageCommand request, CancellationToken cancellationToken)
    {
        var message = new Message
        {
            ChatId = request.ChatId,
            SenderId = request.SenderId,
            Content = request.Content,
            SendAt = DateTime.UtcNow,
        };

        _context.Messages.Add(message);
        await _context.SaveChangesAsync(cancellationToken);

        return message.Id;
    }
}
