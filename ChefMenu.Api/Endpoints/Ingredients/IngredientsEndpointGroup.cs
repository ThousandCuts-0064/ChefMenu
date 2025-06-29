using ChefMenu.Api.Endpoints.Core;
using ChefMenu.Api.Endpoints.Ingredients.Post;

namespace ChefMenu.Api.Endpoints.Ingredients;

public struct IngredientsEndpointGroup : IEndpointGroup
{
    public static RouteGroupBuilder Map(RouteGroupBuilder builder) => builder
        .MapGroup("/ingredients")
        .MapEndpoint<PostIngredientEndpoint>();
}