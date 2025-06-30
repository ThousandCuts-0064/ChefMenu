using ChefMenu.Api.Endpoints.Core;
using ChefMenu.Api.Endpoints.Recipes.Delete;
using ChefMenu.Api.Endpoints.Recipes.Get;
using ChefMenu.Api.Endpoints.Recipes.Patch;
using ChefMenu.Api.Endpoints.Recipes.Post;
using ChefMenu.Api.Endpoints.Recipes.PostSearch;

namespace ChefMenu.Api.Endpoints.Recipes;

public struct RecipesEndpointGroup : IEndpointGroup
{
    public static RouteGroupBuilder Map(RouteGroupBuilder builder) => builder
        .MapGroup("/recipes")
        .MapEndpoint<PostRecipeEndpoint>()
        .MapEndpoint<PostRecipesSearchEndpoint>()
        .MapEndpoint<GetRecipesEndpoint>()
        .MapEndpoint<PatchRecipesEndpoint>()
        .MapEndpoint<DeleteRecipesEndpoint>();
}