using ChefMenu.Api.Endpoints.Core;
using ChefMenu.Domain.Features.Recipes.ValueObjects;

namespace ChefMenu.Api.Endpoints.Recipes.Patch;

public struct PatchRecipesEndpoint : IEndpoint
{
    public static IEndpointConventionBuilder Map(IEndpointRouteBuilder builder)
    {
        return builder.MapPatch("/{id}", (RecipeId id) => { });
    }
}