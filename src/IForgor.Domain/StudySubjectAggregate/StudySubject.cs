using IForgor.Domain.Common.Models;
using IForgor.Domain.DeskAggregate.ValueObjects;
using IForgor.Domain.FieldAggregate.ValueObjects;
using IForgor.Domain.MilestoneAggregate.ValueObjects;
using IForgor.Domain.StudySubjectAggregate.Entities;
using IForgor.Domain.StudySubjectAggregate.ValueObjects;

namespace IForgor.Domain.StudySubjectAggregate;
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
