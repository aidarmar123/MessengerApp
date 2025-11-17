using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;
using MessengerApi.Application.Common.Interfaces;
using MessengerApi.Infrastructure.Identity;
using Microsoft.Extensions.Options;

namespace Microsoft.Extensions.DependencyInjection.Services;

public class JwtService:IJwtService
{
    private readonly JwtOptions _options;

    public JwtService(IOptions<JwtOptions> options)
    {
        _options = options.Value;
    }

    public string GenerateJWTToken(Guid userId)
    {
        var claims = new[] { new Claim(JwtRegisteredClaimNames.Sub, userId.ToString()), };
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_options.Secret));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: _options.Issuer,
            audience: _options.Audience,
            claims: claims,
            expires: DateTime.UtcNow.AddHours(3),
            signingCredentials: creds);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}
