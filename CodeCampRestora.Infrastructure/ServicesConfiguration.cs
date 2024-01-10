using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using CodeCampRestora.Application.Services;
using Microsoft.Extensions.DependencyInjection;
using CodeCampRestora.Infrastructure.Data.DbContexts;
using CodeCampRestora.Application.Common.Interfaces.Services;

namespace CodeCampRestora.Infrastructure;

public static class ServicesConfiguration
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionStringKey = "SupaBaseConnection";
        var assemblyName = Assembly.GetExecutingAssembly().FullName;
        services.AddDbContext<ApplicationDbContext>(options =>
        {
            options.UseNpgsql(configuration.GetConnectionString(connectionStringKey),
                b => b.MigrationsAssembly(assemblyName));
        });

        services.AddScoped<IImageSink>(provider => new ImageFileSink(@"../Images"));
        return services;
    }
}
