using ChefMenu.Api.Endpoints.Core;
using ChefMenu.Api.Endpoints.RecipeCollections.Post;

namespace ChefMenu.Api.Endpoints.RecipeCollections;

public struct RecipeCollectionsEndpointGroup : IEndpointGroup
{
    public static RouteGroupBuilder Map(RouteGroupBuilder builder) => builder
        .MapGroup("/recipe-collections")
        .MapEndpoint<PostRecipeCollectionEndpoint>();
}