using ChefMenu.Api.Endpoints.Core;
using ChefMenu.Domain.Features.Kitchenwares.ValueObjects;

namespace ChefMenu.Api.Endpoints.Kitchenwares.Delete;

public struct DeleteKitchenwaresEndpoint : IEndpoint
{
    public static IEndpointConventionBuilder Map(IEndpointRouteBuilder builder)
    {
        return builder.MapDelete("/{id}", (KitchenwareId id) => { });
    }
}