using IForgor.Domain.Common.Models;
using IForgor.Domain.DeskAggregate.ValueObjects;
using IForgor.Domain.FieldAggregate.ValueObjects;
using IForgor.Domain.ProjectAggregate.ValueObjects;
using IForgor.Domain.StudySubjectAggregate.ValueObjects;
using IForgor.Domain.UserAggregate.ValueObjects;

namespace IForgor.Domain.DeskAggregate;
public sealed class Desk : AggregateRoot<DeskId>
{
    public string Title { get; private set; } = string.Empty;
    public UserId UserId { get; private set;  }
    public List<ProjectId> ProjectIds { get; set; } = [];
    public List<StudySubjectId> StudySubjectIds { get; set; } = [];
    public List<FieldId> FieldIds{ get; set; } = [];

#pragma warning disable CS8618
    private Desk()
    {
    }
#pragma warning restore CS8618

    private Desk(
        DeskId id,
        string title,
        UserId userId) : base(id)
    {
        Title = title;
        UserId = userId;;
    }

    public static Desk Create(
        string title,
        UserId userId)
    {
        return new(DeskId.CreateUnique(), title, userId);
    }
}
