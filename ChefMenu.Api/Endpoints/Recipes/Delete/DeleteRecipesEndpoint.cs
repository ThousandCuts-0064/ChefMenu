using ChefMenu.Api.Endpoints.Core;
using ChefMenu.Domain.Features.Recipes.ValueObjects;

namespace ChefMenu.Api.Endpoints.Recipes.Delete;

public struct DeleteRecipesEndpoint : IEndpoint
{
    public static IEndpointConventionBuilder Map(IEndpointRouteBuilder builder)
    {
        return builder.MapDelete("/{id}", (RecipeId id) => { });
    }
}