using ChefMenu.Api.Endpoints.Core;

namespace ChefMenu.Api.Endpoints.Me.DeleteActions;

public struct DeleteMeActionsEndpoint : IEndpoint
{
    public static IEndpointConventionBuilder Map(IEndpointRouteBuilder builder)
    {
        return builder.MapDelete("/actions", () => { });
    }
}