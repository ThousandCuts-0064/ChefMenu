using ChefMenu.Api.Endpoints.Comments.Delete;
using ChefMenu.Api.Endpoints.Comments.Get;
using ChefMenu.Api.Endpoints.Comments.GetReplies;
using ChefMenu.Api.Endpoints.Comments.Patch;
using ChefMenu.Api.Endpoints.Comments.Post;
using ChefMenu.Api.Endpoints.Core;

namespace ChefMenu.Api.Endpoints.Comments;

public struct CommentsEndpointGroup : IEndpointGroup
{
    public static RouteGroupBuilder Map(RouteGroupBuilder builder) => builder
        .MapGroup("/comments")
        .MapEndpoint<PostCommentsEndpoint>()
        .MapEndpoint<GetCommentsEndpoint>()
        .MapEndpoint<GetCommentsRepliesEndpoint>()
        .MapEndpoint<PatchCommentsEndpoint>()
        .MapEndpoint<DeleteCommentsEndpoint>();
}