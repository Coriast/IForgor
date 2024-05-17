using IForgor.Domain.Common.Models;

namespace IForgor.Domain.MilestoneAggregate.ValueObjects;
public sealed class LongTermId : ValueObject
{
    public Guid Value { get; }

    private LongTermId(Guid value)
    {
        Value = value;
    }

    public static LongTermId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
