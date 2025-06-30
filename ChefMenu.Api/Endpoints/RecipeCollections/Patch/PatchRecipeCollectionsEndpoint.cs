using ChefMenu.Api.Endpoints.Core;
using ChefMenu.Domain.Features.RecipeCollections.ValueObjects;

namespace ChefMenu.Api.Endpoints.RecipeCollections.Patch;

public struct PatchRecipeCollectionsEndpoint : IEndpoint
{
    public static IEndpointConventionBuilder Map(IEndpointRouteBuilder builder)
    {
        return builder.MapPatch("/{id}", (RecipeCollectionId id) => { });
    }
}