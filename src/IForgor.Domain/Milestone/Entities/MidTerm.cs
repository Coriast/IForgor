using IForgor.Domain.Common.Models;
using IForgor.Domain.Milestone.ValueObjects;

namespace IForgor.Domain.Milestone.Entities;
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
