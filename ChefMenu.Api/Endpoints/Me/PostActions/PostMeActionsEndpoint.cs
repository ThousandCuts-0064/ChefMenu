using ChefMenu.Api.Endpoints.Core;

namespace ChefMenu.Api.Endpoints.Me.PostActions;

public struct PostMeActionsEndpoint : IEndpoint
{
    public static IEndpointConventionBuilder Map(IEndpointRouteBuilder builder)
    {
        return builder.MapPost("/actions", () => { });
    }
}