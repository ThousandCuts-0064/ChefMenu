using ChefMenu.Api.Endpoints.Core;

namespace ChefMenu.Api.Endpoints.Me.GetMeCommentsReceived;

public struct GetMeCommentsReceivedEndpoint : IEndpoint
{
    public static IEndpointConventionBuilder Map(IEndpointRouteBuilder builder)
    {
        return builder.MapGet("/comments/received", () => { });
    }
}