using IForgor.Domain.Common.Models;
using IForgor.Domain.DeskAggregate.ValueObjects;

namespace IForgor.Domain.UserAggregate.ValueObjects;
public sealed class UserId : ValueObject
{
    public Guid Value { get; }

    private UserId(Guid value)
    {
        Value = value;
    }

    public static UserId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

    public static UserId Create(string userId)
    {
        return new(Guid.Parse(userId));
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }

}
