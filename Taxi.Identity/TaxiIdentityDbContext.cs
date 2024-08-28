using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Taxi.Identity.Models;

namespace Taxi.Identity;
public class TaxiIdentityDbContext : IdentityDbContext<ApplicationUser>
{
    public TaxiIdentityDbContext()
    {

    }

    public TaxiIdentityDbContext(DbContextOptions<TaxiIdentityDbContext> options) : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder
    .LogTo(Console.WriteLine)
    .EnableSensitiveDataLogging();
}
public class IdentityDesignTimeDbContextFactory : IDesignTimeDbContextFactory<TaxiIdentityDbContext>
{
    public TaxiIdentityDbContext CreateDbContext(string[] args)
    {
        var builder = new DbContextOptionsBuilder<TaxiIdentityDbContext>();

        builder.UseSqlServer("Data Source=DESKTOP-70Q8F0H;Initial Catalog=TaxiIdentity;Integrated Security=True;Trust Server Certificate=True");

        return new TaxiIdentityDbContext(builder.Options);
    }
}