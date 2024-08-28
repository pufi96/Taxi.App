using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using Taxi.Persistence;

namespace Taxi.Api;
public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<TaxiDbContext>
{
    public TaxiDbContext CreateDbContext(string[] args)
    {
        var configuration = new ConfigurationBuilder()
           .SetBasePath(Directory.GetCurrentDirectory())
           .AddJsonFile("appsettings.json")
           .Build();

        var connectionString = configuration.GetConnectionString("TaxiConnectionString");

        var builder = new DbContextOptionsBuilder<TaxiDbContext>();

        builder.UseSqlServer(connectionString);

        return new TaxiDbContext(builder.Options);
    }
}