using IForgor.Domain.Common.Models;

namespace IForgor.Domain.FieldAggregate.ValueObjects;
public sealed class FieldId : ValueObject
{
    public Guid Value { get; }

    private FieldId(Guid value)
    {
        Value = value;
    }

    public static FieldId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
