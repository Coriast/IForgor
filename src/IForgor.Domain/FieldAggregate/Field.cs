using IForgor.Domain.Common.Models;
using IForgor.Domain.FieldAggregate.ValueObjects;

namespace IForgor.Domain.FieldAggregate;
public sealed class Field : AggregateRoot<FieldId>
{
    public string Title { get; }

    private Field(FieldId id, string title) : base(id)
    {
        Title = title;
    }

    private static Field Create(string title)
    {
        return new(FieldId.CreateUnique(), title);
    }
}
