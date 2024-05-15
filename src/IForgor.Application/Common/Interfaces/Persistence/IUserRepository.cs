using IForgor.Domain.Entities;

namespace IForgor.Application.Common.Interfaces.Persistence;
public interface IUserRepository
{
    UserLegacy? GetUserByEmail(string email);
    void Add(UserLegacy user);
}
