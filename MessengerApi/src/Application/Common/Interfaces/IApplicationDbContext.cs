using MessengerApi.Domain.Entities;

namespace MessengerApi.Application.Common.Interfaces;

public interface IApplicationDbContext
{
    DbSet<User> User { get; }
    DbSet<Chat> Chats { get; }
    DbSet<Message> Messages { get; }
    DbSet<Attachment> Attachments { get; }
    DbSet<ChatMember> ChatMembers { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
