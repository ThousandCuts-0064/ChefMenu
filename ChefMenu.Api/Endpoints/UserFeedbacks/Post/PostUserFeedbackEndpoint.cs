using ChefMenu.Api.Endpoints.Core;

namespace ChefMenu.Api.Endpoints.UserFeedbacks.Post;

public struct PostUserFeedbackEndpoint : IEndpoint
{
    public static IEndpointConventionBuilder Map(IEndpointRouteBuilder builder)
    {
        return builder.MapPost("", () => { });
    }
}