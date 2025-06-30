using ChefMenu.Api.Endpoints.Core;
using ChefMenu.Api.Endpoints.UserFeedbacks.Delete;
using ChefMenu.Api.Endpoints.UserFeedbacks.Get;
using ChefMenu.Api.Endpoints.UserFeedbacks.Patch;
using ChefMenu.Api.Endpoints.UserFeedbacks.Post;

namespace ChefMenu.Api.Endpoints.UserFeedbacks;

public struct UserFeedbackEndpointGroup : IEndpointGroup
{
    public static RouteGroupBuilder Map(RouteGroupBuilder builder) => builder
        .MapGroup("/user-feedback")
        .MapEndpoint<PostUserFeedbackEndpoint>()
        .MapEndpoint<GetUserFeedbackEndpoint>()
        .MapEndpoint<PatchUserFeedbackEndpoint>()
        .MapEndpoint<DeleteUserFeedbackEndpoint>();
}