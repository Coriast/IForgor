using ErrorOr;
using IForgor.Domain.Common.Models;

namespace IForgor.Domain.DeskAggregate.ValueObjects;
public sealed class DeskId : ValueObject
{
    public Guid Value { get; }

    private DeskId(Guid value)
    {
        Value = value;
    }

#pragma warning disable CS8618
    protected DeskId()
    {
    }
#pragma warning restore CS8618

    public static DeskId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }

    public static DeskId Create(Guid value)
    {
        return new(value);
    }
}
