using ChefMenu.Api.Endpoints.Core;
using ChefMenu.Api.Endpoints.RecipeCollections.Delete;
using ChefMenu.Api.Endpoints.RecipeCollections.Get;
using ChefMenu.Api.Endpoints.RecipeCollections.Patch;
using ChefMenu.Api.Endpoints.RecipeCollections.Post;
using ChefMenu.Api.Endpoints.RecipeCollections.PostSearch;

namespace ChefMenu.Api.Endpoints.RecipeCollections;

public struct RecipeCollectionsEndpointGroup : IEndpointGroup
{
    public static RouteGroupBuilder Map(RouteGroupBuilder builder) => builder
        .MapGroup("/recipe-collections")
        .MapEndpoint<PostRecipeCollectionsEndpoint>()
        .MapEndpoint<PostRecipeCollectionsSearchEndpoint>()
        .MapEndpoint<GetRecipeCollectionsEndpoint>()
        .MapEndpoint<PatchRecipeCollectionsEndpoint>()
        .MapEndpoint<DeleteRecipeCollectionsEndpoint>();
}