using ChefMenu.Api.Endpoints.Core;
using ChefMenu.Domain.Features.UserFeedbacks.ValueObjects;

namespace ChefMenu.Api.Endpoints.UserFeedbacks.Patch;

public struct PatchUserFeedbackEndpoint : IEndpoint
{
    public static IEndpointConventionBuilder Map(IEndpointRouteBuilder builder)
    {
        return builder.MapPatch("/{id}", (UserFeedbackId id) => { });
    }
}