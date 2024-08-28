using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Taxi.Identity.Models;

namespace Taxi.Identity;
public static class IdentityServiceExtensions
{
    public static void AddIdentityServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddAuthentication(IdentityConstants.ApplicationScheme).AddIdentityCookies();

        services.AddAuthorizationBuilder();

        services.AddDbContext<TaxiIdentityDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("TaxiIdentityConnectionString")));

        services.AddIdentityCore<ApplicationUser>()
            .AddEntityFrameworkStores<TaxiIdentityDbContext>()
            .AddApiEndpoints();
    }
}