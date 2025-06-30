using ChefMenu.Api.Endpoints.Core;

namespace ChefMenu.Api.Endpoints.Me.Patch;

public struct PatchMeEndpoint : IEndpoint
{
    public static IEndpointConventionBuilder Map(IEndpointRouteBuilder builder)
    {
        return builder.MapPatch("", () => { });
    }
}