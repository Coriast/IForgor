using IForgor.Domain.DeskAggregate.ValueObjects;
using IForgor.Domain.FieldAggregate;

namespace IForgor.Application.Common.Interfaces.Persistence;
public interface IFieldRepository
{
    void AddFieldToDesk(Field field, DeskId deskId);
}
