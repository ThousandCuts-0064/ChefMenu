using ChefMenu.Api.Endpoints.Core;
using ChefMenu.Domain.Features.Kitchenwares.ValueObjects;

namespace ChefMenu.Api.Endpoints.Kitchenwares.Get;

public struct GetKitchenwaresEndpoint : IEndpoint
{
    public static IEndpointConventionBuilder Map(IEndpointRouteBuilder builder)
    {
        return builder.MapGet("/{id}", (KitchenwareId id) => { });
    }
}