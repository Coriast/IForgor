using IForgor.Domain.Common.Models;

namespace IForgor.Domain.StudySubject.ValueObjects;
public sealed class StudySubjectMaterialId : ValueObject
{
    public Guid Value { get; }

    private StudySubjectMaterialId(Guid value)
    {
        Value = value;
    }

    public static StudySubjectMaterialId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
