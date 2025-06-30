using ChefMenu.Api.Endpoints.Core;
using ChefMenu.Domain.Features.Comments.ValueObjects;

namespace ChefMenu.Api.Endpoints.Comments.Patch;

public struct PatchCommentsEndpoint : IEndpoint
{
    public static IEndpointConventionBuilder Map(IEndpointRouteBuilder builder)
    {
        return builder.MapPatch("/{id}", (CommentId id) => { });
    }
}