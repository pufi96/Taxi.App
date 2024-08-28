using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Taxi.Aplication.Contracts.Persistence;
using Taxi.Persistence.Repositories;

namespace Taxi.Persistence;
public static class PersistenceServiceRegistration
{
    public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<TaxiDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("TaxiConnectionString")));



        return services;
    }
}