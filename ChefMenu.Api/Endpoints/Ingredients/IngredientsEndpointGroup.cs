using ChefMenu.Api.Endpoints.Core;
using ChefMenu.Api.Endpoints.Ingredients.Delete;
using ChefMenu.Api.Endpoints.Ingredients.Get;
using ChefMenu.Api.Endpoints.Ingredients.GetSearch;
using ChefMenu.Api.Endpoints.Ingredients.Patch;
using ChefMenu.Api.Endpoints.Ingredients.Post;

namespace ChefMenu.Api.Endpoints.Ingredients;

public struct IngredientsEndpointGroup : IEndpointGroup
{
    public static RouteGroupBuilder Map(RouteGroupBuilder builder) => builder
        .MapGroup("/ingredients")
        .MapEndpoint<PostIngredientsEndpoint>()
        .MapEndpoint<GetIngredientsEndpoint>()
        .MapEndpoint<GetIngredientsSearchEndpoint>()
        .MapEndpoint<PatchIngredientsEndpoint>()
        .MapEndpoint<DeleteIngredientsEndpoint>();
}