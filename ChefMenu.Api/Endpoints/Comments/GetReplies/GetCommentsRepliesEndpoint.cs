using ChefMenu.Api.Endpoints.Core;
using ChefMenu.Domain.Features.Comments.ValueObjects;

namespace ChefMenu.Api.Endpoints.Comments.GetReplies;

public struct GetCommentsRepliesEndpoint : IEndpoint
{
    public static IEndpointConventionBuilder Map(IEndpointRouteBuilder builder)
    {
        return builder.MapGet("/{id}/replies", (CommentId id) => { });
    }
}