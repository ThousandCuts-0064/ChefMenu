using ChefMenu.Api.Endpoints.Core;
using ChefMenu.Domain.Features.Recipes.ValueObjects;

namespace ChefMenu.Api.Endpoints.Recipes.Get;

public struct GetRecipesEndpoint : IEndpoint
{
    public static IEndpointConventionBuilder Map(IEndpointRouteBuilder builder)
    {
        return builder.MapGet("/{id}", (RecipeId id) => { });
    }
}