using ChefMenu.Api.Endpoints.Core;
using ChefMenu.Domain.Features.Comments.ValueObjects;

namespace ChefMenu.Api.Endpoints.Comments.Delete;

public struct DeleteCommentsEndpoint : IEndpoint
{
    public static IEndpointConventionBuilder Map(IEndpointRouteBuilder builder)
    {
        return builder.MapDelete("/{id}", (CommentId id) => { });
    }
}