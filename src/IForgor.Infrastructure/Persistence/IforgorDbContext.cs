using IForgor.Domain.DeskAggregate;
using Microsoft.EntityFrameworkCore;

namespace IForgor.Infrastructure.Persistence;
public class IforgorDbContext : DbContext
{
    public IforgorDbContext(DbContextOptions<IforgorDbContext> options) : base(options)
    {
    }

    public DbSet<Desk> Desks { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(IforgorDbContext).Assembly);

        base.OnModelCreating(modelBuilder);
    }
}
