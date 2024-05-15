using IForgor.Application.Common.Interfaces.Persistence;
using IForgor.Domain.Entities;

namespace IForgor.Infrastructure.Persistence;
public class UserRepository : IUserRepository
{
    private static readonly List<UserLegacy> _users = new();

    public void Add(UserLegacy user)
    {
        _users.Add(user);
    }

    public UserLegacy? GetUserByEmail(string email)
    {
        return _users.SingleOrDefault(user => user.Email == email);
    }
}
