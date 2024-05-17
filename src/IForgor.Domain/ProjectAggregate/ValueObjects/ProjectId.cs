﻿using IForgor.Domain.Common.Models;

namespace IForgor.Domain.ProjectAggregate.ValueObjects;
public sealed class ProjectId : ValueObject
{

    public Guid Value { get; }

    private ProjectId(Guid value)
    {
        Value = value;
    }

    public static ProjectId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }

}