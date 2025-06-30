using ChefMenu.Api.Endpoints.Core;

namespace ChefMenu.Api.Endpoints.Me.Delete;

public struct DeleteMeEndpoint : IEndpoint
{
    public static IEndpointConventionBuilder Map(IEndpointRouteBuilder builder)
    {
        return builder.MapDelete("", () => { });
    }
}