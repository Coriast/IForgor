﻿using IForgor.Domain.Common.Models;

namespace IForgor.Domain.StudySubjectAggregate.ValueObjects;
public sealed class StudySubjectId : ValueObject
{
    public Guid Value { get; }

    private StudySubjectId(Guid value)
    {
        Value = value;
    }

#pragma warning disable CS8618
    private StudySubjectId()
    {
    }
#pragma warning restore CS8618

    public static StudySubjectId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
