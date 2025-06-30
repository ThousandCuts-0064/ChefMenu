using ChefMenu.Api.Endpoints.Core;
using ChefMenu.Api.Endpoints.Keywords.Delete;
using ChefMenu.Api.Endpoints.Keywords.Get;
using ChefMenu.Api.Endpoints.Keywords.GetSearch;
using ChefMenu.Api.Endpoints.Keywords.Patch;
using ChefMenu.Api.Endpoints.Keywords.Post;

namespace ChefMenu.Api.Endpoints.Keywords;

public struct KeywordsEndpointGroup : IEndpointGroup
{
    public static RouteGroupBuilder Map(RouteGroupBuilder builder) => builder
        .MapGroup("/keywords")
        .MapEndpoint<PostKeywordsEndpoint>()
        .MapEndpoint<GetKeywordsEndpoint>()
        .MapEndpoint<GetKeywordsSearchEndpoint>()
        .MapEndpoint<PatchKeywordsEndpoint>()
        .MapEndpoint<DeleteKeywordsEndpoint>();
}