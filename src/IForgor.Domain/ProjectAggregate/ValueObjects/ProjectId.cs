using IForgor.Domain.Common.Models;

namespace IForgor.Domain.ProjectAggregate.ValueObjects;
public sealed class ProjectId : ValueObject
{

    public Guid Value { get; }

    private ProjectId(Guid value)
    {
        Value = value;
    }

#pragma warning disable CS8618
    private ProjectId()
    {
    }
#pragma warning restore CS8618

    public static ProjectId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }

}
