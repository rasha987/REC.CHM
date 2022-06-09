using System.Reflection;
using REC.CHM.Core.ProjectAggregate;
using REC.CHM.SharedKernel;
using REC.CHM.SharedKernel.Interfaces;
using Microsoft.EntityFrameworkCore;
using REC.CHM.Core.HouseAggregate;
using REC.CHM.Core.CustomerAggregate;

namespace REC.CHM.Infrastructure.Data;

public class AppDbContext : DbContext
{
  private readonly IDomainEventDispatcher _dispatcher;

  public AppDbContext(DbContextOptions<AppDbContext> options,
    IDomainEventDispatcher dispatcher)
      : base(options)
  {
    _dispatcher = dispatcher;
  }

  //public DbSet<ToDoItem> ToDoItems => Set<ToDoItem>();
  //public DbSet<Project> Projects => Set<Project>();
  public DbSet<House> Houses => Set<House>();
  public DbSet<Address> Addresses => Set<Address>();
  public DbSet<Customer> Customers => Set<Customer>();
  public DbSet<Phone> Phones=> Set<Phone>();

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    base.OnModelCreating(modelBuilder);
    modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
  }

  public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
  {
    int result = await base.SaveChangesAsync(cancellationToken).ConfigureAwait(false);

    // ignore events if no dispatcher provided
    if (_dispatcher == null) return result;

    // dispatch events only if save was successful
    var entitiesWithEvents = ChangeTracker.Entries<EntityBase>()
        .Select(e => e.Entity)
        .Where(e => e.DomainEvents.Any())
        .ToArray();

    await _dispatcher.DispatchAndClearEvents(entitiesWithEvents);

    return result;
  }

  public override int SaveChanges()
  {
    return SaveChangesAsync().GetAwaiter().GetResult();
  }
}
