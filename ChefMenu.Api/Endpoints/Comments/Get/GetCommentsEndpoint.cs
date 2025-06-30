using ChefMenu.Api.Endpoints.Core;
using ChefMenu.Domain.Features.Comments.ValueObjects;
using ChefMenu.Domain.Features.SystemActionHistories.ValueObjects;

namespace ChefMenu.Api.Endpoints.Comments.Get;

public struct GetCommentsEndpoint : IEndpoint
{
    public static IEndpointConventionBuilder Map(IEndpointRouteBuilder builder)
    {
        return builder.MapGet("/{type}/{id}", (EntityName type, CommentId id) => { });
    }
}