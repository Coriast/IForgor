using IForgor.Domain.Common.Models;
using IForgor.Domain.MilestoneAggregate.ValueObjects;

namespace IForgor.Domain.MilestoneAggregate.Entities;
public sealed class MidTerm : Entity<MidTermId>
{
    private MidTerm(MidTermId id) : base(id)
    {
    }

    public static MidTerm Create()
    {
        return new(MidTermId.CreateUnique());
    }
}
