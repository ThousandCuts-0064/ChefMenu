using ChefMenu.Api.Endpoints.Core;
using ChefMenu.Api.Endpoints.Kitchenwares.Post;

namespace ChefMenu.Api.Endpoints.Kitchenwares;

public struct KitchenwaresEndpointGroup : IEndpointGroup
{
    public static RouteGroupBuilder Map(RouteGroupBuilder builder) => builder
        .MapGroup("/kitchenwares")
        .MapEndpoint<PostKitchenwareEndpoint>();
}