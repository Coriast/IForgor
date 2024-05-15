using IForgor.Domain.Common.Models;

namespace IForgor.Domain.Milestone.ValueObjects;
public sealed class MidTermId : ValueObject
{
    public Guid Value { get; }

    private MidTermId(Guid value)
    {
        Value = value;
    }

    public static MidTermId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
