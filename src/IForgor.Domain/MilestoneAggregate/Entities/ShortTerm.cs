using IForgor.Domain.Common.Models;
using IForgor.Domain.MilestoneAggregate.ValueObjects;

namespace IForgor.Domain.MilestoneAggregate.Entities;
public sealed class ShortTerm : Entity<ShortTermId>
{
    private ShortTerm(ShortTermId id) : base(id)
    {
    }

    public static ShortTerm Create()
    {
        return new(ShortTermId.CreateUnique());
    }
}
