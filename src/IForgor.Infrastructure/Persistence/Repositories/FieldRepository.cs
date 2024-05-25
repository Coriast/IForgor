using IForgor.Application.Common.Interfaces.Persistence;
using IForgor.Domain.DeskAggregate.ValueObjects;
using IForgor.Domain.FieldAggregate;

namespace IForgor.Infrastructure.Persistence.Repositories;
public class FieldRepository : IFieldRepository
{
    private readonly IforgorDbContext _dbContext;

    public FieldRepository(IforgorDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public void AddFieldToDesk(Field field, DeskId deskId)
    {
        _dbContext.Add(field);

        var desk = _dbContext.Desks.Find(deskId);

        desk?.FieldIds.Add(field.Id);

        _dbContext.SaveChanges();
    }
}
