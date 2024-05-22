using IForgor.Domain.Common.Models;

namespace IForgor.Domain.FieldAggregate.ValueObjects;
public sealed class FieldId : ValueObject
{
    public Guid Value { get; }

    private FieldId(Guid value)
    {
        Value = value;
    }

#pragma warning disable CS8618
    private FieldId()
    {
    }
#pragma warning restore CS8618

    public static FieldId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
