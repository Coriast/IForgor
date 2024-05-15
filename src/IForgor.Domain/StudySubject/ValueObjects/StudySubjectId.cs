using IForgor.Domain.Common.Models;

namespace IForgor.Domain.StudySubject.ValueObjects;
public sealed class StudySubjectId : ValueObject
{
    public Guid Value { get; }

    private StudySubjectId(Guid value)
    {
        Value = value;
    }

    public static StudySubjectId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
