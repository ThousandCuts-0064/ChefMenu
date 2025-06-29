using ChefMenu.Api.Endpoints.Categories.Post;
using ChefMenu.Api.Endpoints.Core;

namespace ChefMenu.Api.Endpoints.Categories;

public struct CategoriesEndpointGroup : IEndpointGroup
{
    public static RouteGroupBuilder Map(RouteGroupBuilder builder) => builder
        .MapGroup("/categories")
        .MapEndpoint<PostCategoryEndpoint>();
}