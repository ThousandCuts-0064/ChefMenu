using ChefMenu.Api.Endpoints.Core;

namespace ChefMenu.Api.Endpoints.Comments.Post;

public struct PostCommentsEndpoint : IEndpoint
{
    public static IEndpointConventionBuilder Map(IEndpointRouteBuilder builder)
    {
        return builder.MapPost("", () => { });
    }
}