using IForgor.Domain.Common.Models;
using IForgor.Domain.DeskAggregate.ValueObjects;
using IForgor.Domain.FieldAggregate.ValueObjects;
using IForgor.Domain.MilestoneAggregate.ValueObjects;
using IForgor.Domain.ProjectAggregate.Enums;
using IForgor.Domain.ProjectAggregate.ValueObjects;

namespace IForgor.Domain.ProjectAggregate;
public sealed class Project : AggregateRoot<ProjectId>
{

    public string Title { get; } = string.Empty;
    public string Description { get; } = string.Empty;
    public ProjectStatus Status { get; }
    public MilestoneId MilestoneId { get; }
    public FieldId FieldId { get; }
    public DeskId DeskId { get; }
    public DateTime CreatedAt { get; }
 
    private Project(
        ProjectId id,
        string title,
        string description,
        ProjectStatus status,
        MilestoneId milestoneId,
        FieldId fieldId,
        DeskId deskId,
        DateTime createdAt) : base(id)
    {
        Title = title;
        Description = description;
        Status = status;
        MilestoneId = milestoneId;
        FieldId = fieldId;
        DeskId = deskId;
        CreatedAt = createdAt;
    }

    public static Project Create(
        string title,
        string description,
        ProjectStatus status,
        MilestoneId milestoneId,
        FieldId fieldId,
        DeskId deskId)
    {
        return new(
            ProjectId.CreateUnique(),
            title,
            description,
            status,
            milestoneId,
            fieldId,
            deskId,
            DateTime.UtcNow);
    }
}
