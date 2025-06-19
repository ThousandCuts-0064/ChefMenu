using Microsoft.Extensions.DependencyInjection;

namespace ChefMenu.Application.Core.Features;

public interface IFeature
{
    public static abstract IServiceCollection Add(IServiceCollection services);
}