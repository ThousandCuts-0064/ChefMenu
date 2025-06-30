using ChefMenu.Api.Endpoints.Core;
using ChefMenu.Domain.Features.RecipeCollections.ValueObjects;

namespace ChefMenu.Api.Endpoints.RecipeCollections.Delete;

public struct DeleteRecipeCollectionsEndpoint : IEndpoint
{
    public static IEndpointConventionBuilder Map(IEndpointRouteBuilder builder)
    {
        return builder.MapDelete("/{id}", (RecipeCollectionId id) => { });
    }
}