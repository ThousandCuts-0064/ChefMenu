using ChefMenu.Api.Endpoints.Core;

namespace ChefMenu.Api.Endpoints.Me.GetActions;

public struct GetMeActionsEndpoint : IEndpoint
{
    public static IEndpointConventionBuilder Map(IEndpointRouteBuilder builder)
    {
        return builder.MapGet("/actions", () => { });
    }
}