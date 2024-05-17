using IForgor.Application.Common.Interfaces.Persistence;
using IForgor.Domain.DeskAggregate;

namespace IForgor.Infrastructure.Persistence;
public class DeskRepository : IDeskRepository
{
    private static readonly List<Desk> _desks = new();

    public void Add(Desk desk)
    {
        _desks.Add(desk);
    }
}
