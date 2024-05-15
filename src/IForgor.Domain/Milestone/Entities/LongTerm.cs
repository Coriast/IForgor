using IForgor.Domain.Common.Models;
using IForgor.Domain.Milestone.ValueObjects;

namespace IForgor.Domain.Milestone.Entities;
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
