﻿using IForgor.Domain.Common.Models;
using IForgor.Domain.MilestoneAggregate.Entities;
using IForgor.Domain.MilestoneAggregate.ValueObjects;

namespace IForgor.Domain.MilestoneAggregate;
public sealed class Milestone : AggregateRoot<MilestoneId>
{
    public ShortTerm shortTerm { get; }
    public MidTerm midTerm { get; }
    public LongTerm longTerm { get; }

    private Milestone(MilestoneId id, ShortTerm shortTerm, MidTerm midTerm, LongTerm longTerm) : base(id)
    {
        this.shortTerm = shortTerm;
        this.midTerm = midTerm;
        this.longTerm = longTerm;
    }

    public static Milestone Create(ShortTerm shortTerm, MidTerm midTerm, LongTerm longTerm)
    {
        return new(MilestoneId.CreateUnique(), shortTerm, midTerm, longTerm);
    }
}