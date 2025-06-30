using ChefMenu.Api.Endpoints.Core;

namespace ChefMenu.Api.Endpoints.Recipes.PostSearch;

public struct PostRecipesSearchEndpoint : IEndpoint
{
    public static IEndpointConventionBuilder Map(IEndpointRouteBuilder builder)
    {
        return builder.MapPost("/search", () => { });
    }
}