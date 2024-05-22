using IForgor.Domain.Common.Models;
using IForgor.Domain.DeskAggregate.ValueObjects;
using IForgor.Domain.FieldAggregate.ValueObjects;

namespace IForgor.Domain.FieldAggregate;
public sealed class Field : AggregateRoot<FieldId>
{
    public string Title { get; }
    public DeskId DeskId { get; }

    private Field(FieldId id, string title, DeskId deskId) : base(id)
    {
        Title = title;
        DeskId = deskId;
    }

#pragma warning disable CS8618
    private Field()
    {
    }
#pragma warning restore CS8618

    public static Field Create(string title, DeskId deskId)
    {
        return new(FieldId.CreateUnique(), title, deskId);
    }
}
