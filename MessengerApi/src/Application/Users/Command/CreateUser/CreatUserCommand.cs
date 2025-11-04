namespace Microsoft.Extensions.DependencyInjection.Users.Command.CreateUser;

public record CreatUserCommand(string firstName, string lastName, string displayname, string alice):IRequest<Guid>;
