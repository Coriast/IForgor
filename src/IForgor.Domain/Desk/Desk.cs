using IForgor.Domain.Common.Models;
using IForgor.Domain.Desk.ValueObjects;

namespace IForgor.Domain.Desk;
public sealed class Desk : AggregateRoot<DeskId>
{
    public string Title { get; } = string.Empty;

    private Desk(DeskId id, string title) : base(id)
    {
        Title = title;
    }

    public static Desk Create(string title)
    {
        return new(DeskId.CreateUnique(), title);
    }
}
