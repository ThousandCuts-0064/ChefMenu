using ChefMenu.Api.Endpoints.Core;
using ChefMenu.Domain.Features.Ingredients.ValueObjects;

namespace ChefMenu.Api.Endpoints.Ingredients.Patch;

public struct PatchIngredientsEndpoint : IEndpoint
{
    public static IEndpointConventionBuilder Map(IEndpointRouteBuilder builder)
    {
        return builder.MapPatch("/{id}", (IngredientId id) => { });
    }
}