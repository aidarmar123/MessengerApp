namespace Microsoft.Extensions.DependencyInjection.Auth.Command;

public record AuthCommand(string displayName):IRequest<AuthDto>;
