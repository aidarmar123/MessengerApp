using MessengerApi.Application.Common.Interfaces;
using MessengerApi.Domain.Entities;
using Microsoft.Extensions.DependencyInjection.Messages.Queries.GetMessages;

namespace Microsoft.Extensions.DependencyInjection.Users.Command.CreateUser;

public class CreatUserCommandHandler:IRequestHandler<CreatUserCommand, Guid>
{
    private readonly IApplicationDbContext _context;

    public CreatUserCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Guid> Handle(CreatUserCommand request, CancellationToken cancellationToken)
    {
        var user = new User()
        {
            FirstName = request.firstName,
            LastName = request.lastName,
            Displayname = request.displayname,
            Alice = request.alice
        };
        _context.User.Add(user);
        await _context.SaveChangesAsync(cancellationToken);
        return user.Id;
    }
}
