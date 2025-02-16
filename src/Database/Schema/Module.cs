using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Schema;
public static class Module
{
    public static IServiceCollection AddSchema(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
        {
            options.UseNpgsql(configuration.GetConnectionString("Postgres"));
            options.UseSnakeCaseNamingConvention();
        });

        return services;
    }
}
