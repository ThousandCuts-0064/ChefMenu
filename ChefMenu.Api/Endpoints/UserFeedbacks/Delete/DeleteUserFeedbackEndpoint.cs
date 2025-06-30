using ChefMenu.Api.Endpoints.Core;
using ChefMenu.Domain.Features.UserFeedbacks.ValueObjects;

namespace ChefMenu.Api.Endpoints.UserFeedbacks.Delete;

public struct DeleteUserFeedbackEndpoint : IEndpoint
{
    public static IEndpointConventionBuilder Map(IEndpointRouteBuilder builder)
    {
        return builder.MapDelete("/{id}", (UserFeedbackId id) => { });
    }
}