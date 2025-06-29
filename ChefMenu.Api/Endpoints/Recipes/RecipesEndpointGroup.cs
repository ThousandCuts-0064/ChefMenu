using ChefMenu.Api.Endpoints.Core;
using ChefMenu.Api.Endpoints.Recipes.Post;

namespace ChefMenu.Api.Endpoints.Recipes;

public struct RecipesEndpointGroup : IEndpointGroup
{
    public static RouteGroupBuilder Map(RouteGroupBuilder builder) => builder
        .MapGroup("/recipes")
        .MapEndpoint<PostRecipeEndpoint>();
}