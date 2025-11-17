using MessengerApi.Application.Common.Interfaces;
using MessengerApi.Domain.Entities;
using Microsoft.Extensions.DependencyInjection.Messages.Queries.GetMessages;

namespace Microsoft.Extensions.DependencyInjection.Messages.Command.SendMessage;

public class SendMessageCommandHandler:IRequestHandler<SendMessageCommand, Guid>
{
    private readonly IApplicationDbContext _context;
    private readonly IMessageNotifier _messageNotifier;

    public SendMessageCommandHandler(IApplicationDbContext context, IMessageNotifier notifier)
    {
        _context = context;
        _messageNotifier = notifier;
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

        await _messageNotifier.SendNotificationToAllAsync(new MessageDto()
        {
            ChatId = message.ChatId,
            SenderId = message.SenderId,
            Content = message.Content,
            SentAt = message.SendAt,
        });
        return message.Id;
    }
}
