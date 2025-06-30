using ChefMenu.Api.Endpoints.Core;

namespace ChefMenu.Api.Endpoints.RecipeCollections.PostSearch;

public struct PostRecipeCollectionsSearchEndpoint : IEndpoint
{
    public static IEndpointConventionBuilder Map(IEndpointRouteBuilder builder)
    {
        return builder.MapPost("/search", () => { });
    }
}