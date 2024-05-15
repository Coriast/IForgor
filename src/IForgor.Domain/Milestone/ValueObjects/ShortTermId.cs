using IForgor.Domain.Common.Models;

namespace IForgor.Domain.Milestone.ValueObjects;
public sealed class ShortTermId : ValueObject
{
    public Guid Value { get; }

    private ShortTermId(Guid value)
    {
        Value = value;
    }

    public static ShortTermId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
