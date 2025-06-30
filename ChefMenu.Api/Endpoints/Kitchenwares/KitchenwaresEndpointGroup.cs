using ChefMenu.Api.Endpoints.Core;
using ChefMenu.Api.Endpoints.Kitchenwares.Delete;
using ChefMenu.Api.Endpoints.Kitchenwares.Get;
using ChefMenu.Api.Endpoints.Kitchenwares.GetSearch;
using ChefMenu.Api.Endpoints.Kitchenwares.Patch;
using ChefMenu.Api.Endpoints.Kitchenwares.Post;

namespace ChefMenu.Api.Endpoints.Kitchenwares;

public struct KitchenwaresEndpointGroup : IEndpointGroup
{
    public static RouteGroupBuilder Map(RouteGroupBuilder builder) => builder
        .MapGroup("/kitchenwares")
        .MapEndpoint<PostKitchenwaresEndpoint>()
        .MapEndpoint<GetKitchenwaresEndpoint>()
        .MapEndpoint<GetKitchenwaresSearchEndpoint>()
        .MapEndpoint<PatchKitchenwaresEndpoint>()
        .MapEndpoint<DeleteKitchenwaresEndpoint>();
}