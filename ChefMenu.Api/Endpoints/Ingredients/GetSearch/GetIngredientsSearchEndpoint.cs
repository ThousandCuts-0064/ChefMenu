using ChefMenu.Api.Endpoints.Core;

namespace ChefMenu.Api.Endpoints.Ingredients.GetSearch;

public struct GetIngredientsSearchEndpoint : IEndpoint
{
    public static IEndpointConventionBuilder Map(IEndpointRouteBuilder builder)
    {
        return builder.MapGet("/search", () => { });
    }
}