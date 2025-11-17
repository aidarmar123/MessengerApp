using System.Security.Claims;

namespace MessengerApi.Application.Common.Interfaces;

public interface IJwtService
{
   string GenerateJWTToken(Guid userId);
}
