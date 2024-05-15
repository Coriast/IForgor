using IForgor.Domain.Common.Models;

namespace IForgor.Domain.Milestone.ValueObjects;
public sealed class MilestoneId : ValueObject
{
    public Guid Value { get; }

    private MilestoneId(Guid value)
    {
        Value = value;
    }

    public static MilestoneId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
