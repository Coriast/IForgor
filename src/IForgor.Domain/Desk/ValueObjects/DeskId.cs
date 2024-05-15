using IForgor.Domain.Common.Models;

namespace IForgor.Domain.Desk.ValueObjects;
public sealed class DeskId : ValueObject
{
    public Guid Value { get; }

    private DeskId(Guid value)
    {
        Value = value;
    }

    public static DeskId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
