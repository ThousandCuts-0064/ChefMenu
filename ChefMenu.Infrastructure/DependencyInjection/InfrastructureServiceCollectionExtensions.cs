using ChefMenu.Application;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace ChefMenu.Infrastructure.DependencyInjection;

public static class InfrastructureServiceCollectionExtensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, InfrastructureOptions options)
    {
        return services
            .AddDbContext<IAppDbContext, AppDbContext>(x =>
            {
                x.UseNpgsql(options.ConnectionString);

                if (options.IsDevelopment)
                {
                    x.EnableDetailedErrors().EnableSensitiveDataLogging();
                }
            });
    }
}