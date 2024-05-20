using IForgor.Domain.Common.Models;
using IForgor.Domain.DeskAggregate.ValueObjects;
using IForgor.Domain.FieldAggregate.ValueObjects;
using IForgor.Domain.ProjectAggregate.ValueObjects;
using IForgor.Domain.StudySubjectAggregate.ValueObjects;
using IForgor.Domain.UserAggregate.ValueObjects;

namespace IForgor.Domain.DeskAggregate;
public sealed class Desk : AggregateRoot<DeskId>
{
    private readonly List<ProjectId> _projectIds = new();
    private readonly List<StudySubjectId> _studySubjectIds = new();
    private readonly List<FieldId> _fieldIds = new();
    public string Title { get; private set; } = string.Empty;
    public UserId UserId { get; private set;  }
    public IReadOnlyList<ProjectId> ProjectIds => _projectIds.AsReadOnly();
    public IReadOnlyList<StudySubjectId> StudySubjectIds => _studySubjectIds.AsReadOnly(); 
    public IReadOnlyList<FieldId> FieldIds => _fieldIds.AsReadOnly();

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
