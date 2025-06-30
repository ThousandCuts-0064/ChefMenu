using ChefMenu.Api.Endpoints.Core;

namespace ChefMenu.Api.Endpoints.Categories.GetSearch;

public struct GetCategoriesSearchEndpoint : IEndpoint
{
    public static IEndpointConventionBuilder Map(IEndpointRouteBuilder builder)
    {
        return builder.MapGet("/search", () => { });
    }
}