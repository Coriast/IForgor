using IForgor.Domain.Common.Models;
using IForgor.Domain.DeskAggregate.ValueObjects;
using IForgor.Domain.FieldAggregate.ValueObjects;
using IForgor.Domain.ProjectAggregate.Enums;
using IForgor.Domain.StudySubjectAggregate.Entities;
using IForgor.Domain.StudySubjectAggregate.ValueObjects;

namespace IForgor.Domain.StudySubjectAggregate;
public sealed class StudySubject : AggregateRoot<StudySubjectId>
{
    private readonly List<StudySubjectMaterial> _materials = new();
    public string Title { get; }
    public IReadOnlyList<StudySubjectMaterial> Materials { get {  return _materials.AsReadOnly(); } }
    public FieldId FieldId { get; }
    public Milestone MilestoneType { get; }
    public DeskId DeskId { get; }
    public DateTime CreatedAt { get; }

    private StudySubject(
        StudySubjectId id,
        string title,
        List<StudySubjectMaterial> materials,
        FieldId fieldId,
        Milestone milestoneType,
        DeskId deskId,
        DateTime createdAt) : base(id)
    {
        _materials = materials;
        Title = title;
        FieldId = fieldId;
        MilestoneType = milestoneType;
        DeskId = deskId;
        CreatedAt = createdAt;
    }

#pragma warning disable CS8618
    private StudySubject()
    {
    }
#pragma warning restore CS8618

    public static StudySubject Create(
        string title,
        List<StudySubjectMaterial> materials,
        FieldId fieldId,
        Milestone milestoneType,
        DeskId deskId)
    {
        return new(
            StudySubjectId.CreateUnique(),
            title,
            materials,
            fieldId,
            milestoneType,
            deskId,
            DateTime.UtcNow);
    }
}
