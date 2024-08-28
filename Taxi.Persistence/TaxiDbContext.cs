using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System.Reflection;
using Taxi.Aplication.Contracts;
using Taxi.Domain.Common;
using Taxi.Domain.Entities;

namespace Taxi.Persistence;
public class TaxiDbContext : DbContext
{
    private readonly ILoggedInUserService? _loggedInUserService;
    public TaxiDbContext(DbContextOptions<TaxiDbContext> options) : base(options)
    {
    }
    public TaxiDbContext(DbContextOptions<TaxiDbContext> options, ILoggedInUserService loggedInUserService)
        : base(options)
    {
        _loggedInUserService = loggedInUserService;
    }

    public DbSet<Car> Cars { get; set; }
    public DbSet<CarBrand> CarBrands { get; set; }
    public DbSet<CarModel> CarModels { get; set; }
    public DbSet<DebtCollection> DebtCollections { get; set; }
    public DbSet<Debtor> Debtors { get; set; }
    public DbSet<FuelType> FuelTypes { get; set; }
    public DbSet<InDebted> InDebteds { get; set; }
    public DbSet<Location> Locations { get; set; }
    public DbSet<LocationPrice> LocationPrices { get; set; }
    public DbSet<Maintenance> Maintenances { get; set; }
    public DbSet<MaintenanceType> MaintenanceTypes { get; set; }
    public DbSet<Ride> Rides { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<RoleUseCase> RoleUseCase { get; set; }
    public DbSet<Shift> Shifts { get; set; }
    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
    {
        foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
        {
            switch (entry.State)
            {
                case EntityState.Added:
                    entry.Entity.CreatedDate = DateTime.UtcNow;
                    entry.Entity.CreatedBy = _loggedInUserService.UserId;
                    break;
                case EntityState.Modified:
                    entry.Entity.LastModifiedDate = DateTime.UtcNow;
                    entry.Entity.LastModifiedBy = _loggedInUserService.UserId;
                    break;
                case EntityState.Deleted:
                    entry.Entity.LastModifiedDate = DateTime.UtcNow;
                    entry.Entity.LastModifiedBy = _loggedInUserService.UserId;
                    entry.Entity.IsActive = false;
                    break;

            }
        }
        return base.SaveChangesAsync(cancellationToken);
    }
}

