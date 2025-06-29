using ChefMenu.Api.Endpoints.Core;
using ChefMenu.Api.Endpoints.Keywords.Post;

namespace ChefMenu.Api.Endpoints.Keywords;

public struct KeywordsEndpointGroup : IEndpointGroup
{
    public static RouteGroupBuilder Map(RouteGroupBuilder builder) => builder
        .MapGroup("/keywords")
        .MapEndpoint<PostKeywordEndpoint>();
}