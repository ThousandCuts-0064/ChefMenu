using ChefMenu.Api.Endpoints.Core;

namespace ChefMenu.Api.Endpoints.Keywords.GetSearch;

public struct GetKeywordsSearchEndpoint : IEndpoint
{
    public static IEndpointConventionBuilder Map(IEndpointRouteBuilder builder)
    {
        return builder.MapGet("/search", () => { });
    }
}