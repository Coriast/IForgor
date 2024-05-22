using IForgor.Domain.Common.Models;
using IForgor.Domain.UserAggregate.ValueObjects;

namespace IForgor.Domain.UserAggregate;
public class User : AggregateRoot<UserId>
{
    public string Nickname { get; } = string.Empty;
    public string Email { get; } = string.Empty;
    public string Password { get; } = string.Empty;
    public DateTime CreatedAt { get; }

    private User(UserId id, string nickname, string email, string password, DateTime createdAt) : base(id)
    {
        Nickname = nickname;
        Email = email;
        Password = password;
        CreatedAt = createdAt;
    }

#pragma warning disable CS8618
    private User()
    {
    }
#pragma warning restore CS8618

    public static User Create(string nickname,  string email, string password)
    {
        return new(UserId.CreateUnique(), nickname, email, password, DateTime.UtcNow);
    }
}
