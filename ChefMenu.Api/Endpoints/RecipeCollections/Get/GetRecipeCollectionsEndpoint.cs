using ChefMenu.Api.Endpoints.Core;
using ChefMenu.Domain.Features.RecipeCollections.ValueObjects;

namespace ChefMenu.Api.Endpoints.RecipeCollections.Get;

public struct GetRecipeCollectionsEndpoint : IEndpoint
{
    public static IEndpointConventionBuilder Map(IEndpointRouteBuilder builder)
    {
        return builder.MapGet("/{id}", (RecipeCollectionId id) => { });
    }
}