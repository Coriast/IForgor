using IForgor.Domain.Entities;

namespace IForgor.Application.Common.Interfaces.Authentication;
public interface IJwtTokenGenerator
{
    string GenerateToken(UserLegacy user);
}
