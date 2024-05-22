using IForgor.Domain.Common.Models;

namespace IForgor.Domain.StudySubjectAggregate.ValueObjects;
public sealed class StudySubjectMaterialId : ValueObject
{
    public Guid Value { get; }

    private StudySubjectMaterialId(Guid value)
    {
        Value = value;
    }

#pragma warning disable CS8618
    private StudySubjectMaterialId()
    {
    }
#pragma warning restore CS8618

    public static StudySubjectMaterialId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
