using ChefMenu.Api.Endpoints.Categories.Delete;
using ChefMenu.Api.Endpoints.Categories.Get;
using ChefMenu.Api.Endpoints.Categories.GetSearch;
using ChefMenu.Api.Endpoints.Categories.Patch;
using ChefMenu.Api.Endpoints.Categories.Post;
using ChefMenu.Api.Endpoints.Core;

namespace ChefMenu.Api.Endpoints.Categories;

public struct CategoriesEndpointGroup : IEndpointGroup
{
    public static RouteGroupBuilder Map(RouteGroupBuilder builder) => builder
        .MapGroup("/categories")
        .MapEndpoint<PostCategoriesEndpoint>()
        .MapEndpoint<GetCategoriesEndpoint>()
        .MapEndpoint<GetCategoriesSearchEndpoint>()
        .MapEndpoint<PatchCategoriesEndpoint>()
        .MapEndpoint<DeleteCategoriesEndpoint>();
}