using ChefMenu.Api.Endpoints.Ai.Post;
using ChefMenu.Api.Endpoints.Core;

namespace ChefMenu.Api.Endpoints.Ai;

public struct AiEndpointGroup : IEndpointGroup
{
    public static RouteGroupBuilder Map(RouteGroupBuilder builder) => builder
        .MapGroup("/ai")
        .MapEndpoint<PostAiEndpoint>();
}
