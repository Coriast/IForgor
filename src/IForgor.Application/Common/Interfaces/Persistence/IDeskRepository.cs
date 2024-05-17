using IForgor.Domain.DeskAggregate;

namespace IForgor.Application.Common.Interfaces.Persistence;
public interface IDeskRepository
{
    void Add(Desk desk);
}
