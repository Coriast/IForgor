using IForgor.Application.Common.Interfaces.Persistence;
using IForgor.Domain.DeskAggregate;

namespace IForgor.Infrastructure.Persistence.Repositories;
public class DeskRepository : IDeskRepository
{
    private readonly IforgorDbContext _dbContext;

    public DeskRepository(IforgorDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public void Add(Desk desk)
    {
        _dbContext.Add(desk);

        _dbContext.SaveChanges();
    }
}
