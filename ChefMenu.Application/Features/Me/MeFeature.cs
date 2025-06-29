using ChefMenu.Application.Core.Features;
using ChefMenu.Application.Core.Mediators;
using ChefMenu.Application.Features.Me.Queries.Get;
using Microsoft.Extensions.DependencyInjection;

namespace ChefMenu.Application.Features.Me;

public struct MeFeature : IFeature
{
    public static IServiceCollection Add(IServiceCollection services) => services
        .AddQuery<GetMeQuery, GetMeQueryHandler>();
}