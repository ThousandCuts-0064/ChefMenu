using ChefMenu.Api.Endpoints.Core;
using ChefMenu.Domain.Features.Kitchenwares.ValueObjects;

namespace ChefMenu.Api.Endpoints.Kitchenwares.Patch;

public struct PatchKitchenwaresEndpoint : IEndpoint
{
    public static IEndpointConventionBuilder Map(IEndpointRouteBuilder builder)
    {
        return builder.MapPatch("/{id}", (KitchenwareId id) => { });
    }
}