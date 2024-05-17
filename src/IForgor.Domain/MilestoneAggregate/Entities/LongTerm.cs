using IForgor.Domain.Common.Models;
using IForgor.Domain.MilestoneAggregate.ValueObjects;

namespace IForgor.Domain.MilestoneAggregate.Entities;
public sealed class LongTerm : Entity<LongTermId>
{
    public LongTerm(LongTermId id) : base(id)
    {
    }

    public static LongTerm Create()
    {
        return new(LongTermId.CreateUnique());
    }
}
