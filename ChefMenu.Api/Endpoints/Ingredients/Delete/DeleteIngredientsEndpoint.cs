using ChefMenu.Api.Endpoints.Core;
using ChefMenu.Domain.Features.Ingredients.ValueObjects;

namespace ChefMenu.Api.Endpoints.Ingredients.Delete;

public struct DeleteIngredientsEndpoint : IEndpoint
{
    public static IEndpointConventionBuilder Map(IEndpointRouteBuilder builder)
    {
        return builder.MapDelete("/{id}", (IngredientId id) => { });
    }
}