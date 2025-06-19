using Microsoft.Extensions.DependencyInjection;

namespace ChefMenu.Application.Core.Features;

public static class FeatureServiceCollectionExtensions
{
    public static IServiceCollection AddFeature<TFeature>(this IServiceCollection services)
        where TFeature : struct, IFeature
    {
        TFeature.Add(services);

        return services;
    }
}
