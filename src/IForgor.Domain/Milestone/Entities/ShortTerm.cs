using IForgor.Domain.Common.Models;
using IForgor.Domain.Milestone.ValueObjects;

namespace IForgor.Domain.Milestone.Entities;
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
