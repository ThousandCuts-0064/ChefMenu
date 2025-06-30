using ChefMenu.Api.Endpoints.Core;

namespace ChefMenu.Api.Endpoints.Me.PatchActions;

public struct PatchMeActionsEndpoint : IEndpoint
{
    public static IEndpointConventionBuilder Map(IEndpointRouteBuilder builder)
    {
        return builder.MapPatch("/actions", () => { });
    }
}