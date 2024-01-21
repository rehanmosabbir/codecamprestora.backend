using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using CodeCampRestora.Infrastructure.Data.DbContexts;

namespace CodeCampRestora.Infrastructure;

public static class ServicesConfiguration
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionStringKey = "ProductionConnection";
        //var connectionStringKey = "SupaBaseConnection";
        var assemblyName = Assembly.GetExecutingAssembly().FullName;
        services.AddDbContext<ApplicationDbContext>(options =>
        {
            options.UseNpgsql(configuration.GetConnectionString(connectionStringKey),
                b => b.MigrationsAssembly(assemblyName));
        });

        return services;
    }
}