using MessengerApi.Application.Common.Exceptions;
using MessengerApi.Application.Common.Interfaces;

namespace Microsoft.Extensions.DependencyInjection.Auth.Command;

public class AuthCommandHandler:IRequestHandler<AuthCommand, AuthDto>
{
    private readonly IApplicationDbContext _context;
    private readonly IJwtService _jwtService;

    public AuthCommandHandler(IApplicationDbContext context, IJwtService jwtService)
    {
        _context = context;
        _jwtService = jwtService;
    }

    public async Task<AuthDto> Handle(AuthCommand request, CancellationToken cancellationToken)
    {
        var user = await _context.User
            .FirstOrDefaultAsync(x => x.Displayname == request.displayName);
        if(user is null)
            throw new UnauthorizedException($"User with displayname '{request.displayName}' does not exist");
        var token =  _jwtService.GenerateJWTToken(user.Id);
        return new AuthDto() { Username = user.Displayname, Token = token, };
    }
}
