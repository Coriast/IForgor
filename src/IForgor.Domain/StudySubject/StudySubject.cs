using IForgor.Domain.Common.Models;
using IForgor.Domain.Desk.ValueObjects;
using IForgor.Domain.Field.ValueObjects;
using IForgor.Domain.Milestone.ValueObjects;
using IForgor.Domain.StudySubject.Entities;
using IForgor.Domain.StudySubject.ValueObjects;

namespace IForgor.Domain.StudySubject;
public sealed class StudySubject : AggregateRoot<StudySubjectId>
{
    private readonly List<StudySubjectMaterial> _materials = new();
    public string Title { get; }
    public IReadOnlyList<StudySubjectMaterial> Materials { get {  return _materials.AsReadOnly(); } }
    public FieldId FieldId { get; }
    public MilestoneId MilestoneId { get; }
    public DeskId DeskId { get; }
    public DateTime CreatedAt { get; }

    private StudySubject(
        StudySubjectId id,
        string title,
        List<StudySubjectMaterial> materials,
        FieldId fieldId,
        MilestoneId milestoneId,
        DeskId deskId,
        DateTime createdAt) : base(id)
    {
        _materials = materials;
        Title = title;
        FieldId = fieldId;
        MilestoneId = milestoneId;
        DeskId = deskId;
        CreatedAt = createdAt;
    }

    public static StudySubject Create(
        string title,
        List<StudySubjectMaterial> materials,
        FieldId fieldId,
        MilestoneId milestoneId,
        DeskId deskId)
    {
        return new(
            StudySubjectId.CreateUnique(),
            title,
            materials,
            fieldId,
            milestoneId,
            deskId,
            DateTime.UtcNow);
    }
}
