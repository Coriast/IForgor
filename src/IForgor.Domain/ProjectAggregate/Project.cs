using IForgor.Domain.Common.Models;
using IForgor.Domain.DeskAggregate.ValueObjects;
using IForgor.Domain.FieldAggregate.ValueObjects;
using IForgor.Domain.ProjectAggregate.Enums;
using IForgor.Domain.ProjectAggregate.ValueObjects;

namespace IForgor.Domain.ProjectAggregate;
public sealed class Project : AggregateRoot<ProjectId>
{

    public string Title { get; } = string.Empty;
    public string Description { get; } = string.Empty;
    public ProjectStatus Status { get; }
    public Milestone MilestoneType { get; }
    public FieldId FieldId { get; }
    public DeskId DeskId { get; }
    public DateTime CreatedAt { get; }
 
    private Project(
        ProjectId id,
        string title,
        string description,
        ProjectStatus status,
        Milestone milestoneType,
        FieldId fieldId,
        DeskId deskId,
        DateTime createdAt) : base(id)
    {
        Title = title;
        Description = description;
        Status = status;
        MilestoneType = milestoneType;
        FieldId = fieldId;
        DeskId = deskId;
        CreatedAt = createdAt;
    }

#pragma warning disable CS8618
    private Project()
    {
    }
#pragma warning restore CS8618

    public static Project Create(
        string title,
        string description,
        ProjectStatus status,
        Milestone milestoneType,
        FieldId fieldId,
        DeskId deskId)
    {
        return new(
            ProjectId.CreateUnique(),
            title,
            description,
            status,
            milestoneType,
            fieldId,
            deskId,
            DateTime.UtcNow);
    }
}
