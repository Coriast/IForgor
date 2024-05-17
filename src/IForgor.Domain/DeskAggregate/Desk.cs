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
    public string Title { get; } = string.Empty;
    public UserId UserId { get; }
    public IReadOnlyList<ProjectId> ProjectIds { get { return _projectIds.AsReadOnly(); } }
    public IReadOnlyList<StudySubjectId> StudySubjectIds { get { return _studySubjectIds.AsReadOnly(); } }
    public IReadOnlyList<FieldId> FieldIds { get { return _fieldIds.AsReadOnly(); } }

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
