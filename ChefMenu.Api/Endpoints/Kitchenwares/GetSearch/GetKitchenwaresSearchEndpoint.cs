using ChefMenu.Api.Endpoints.Core;

namespace ChefMenu.Api.Endpoints.Kitchenwares.GetSearch;

public struct GetKitchenwaresSearchEndpoint : IEndpoint
{
    public static IEndpointConventionBuilder Map(IEndpointRouteBuilder builder)
    {
        return builder.MapGet("/search", () => { });
    }
}