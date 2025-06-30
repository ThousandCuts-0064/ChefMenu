using ChefMenu.Api.Endpoints.Core;
using ChefMenu.Domain.Features.UserFeedbacks.ValueObjects;

namespace ChefMenu.Api.Endpoints.UserFeedbacks.Get;

public struct GetUserFeedbackEndpoint : IEndpoint
{
    public static IEndpointConventionBuilder Map(IEndpointRouteBuilder builder)
    {
        return builder.MapGet("/{id}", (UserFeedbackId id) => { });
    }
}