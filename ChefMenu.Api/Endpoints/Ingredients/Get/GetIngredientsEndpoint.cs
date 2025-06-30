using ChefMenu.Api.Endpoints.Core;
using ChefMenu.Domain.Features.Ingredients.ValueObjects;

namespace ChefMenu.Api.Endpoints.Ingredients.Get;

public struct GetIngredientsEndpoint : IEndpoint
{
    public static IEndpointConventionBuilder Map(IEndpointRouteBuilder builder)
    {
        return builder.MapGet("/{id}", (IngredientId id) => { });
    }
}