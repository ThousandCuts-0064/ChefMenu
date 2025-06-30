using ChefMenu.Api.Endpoints.Core;
using ChefMenu.Domain.Features.Keywords.ValueObjects;

namespace ChefMenu.Api.Endpoints.Keywords.Get;

public struct GetKeywordsEndpoint : IEndpoint
{
    public static IEndpointConventionBuilder Map(IEndpointRouteBuilder builder)
    {
        return builder.MapGet("/{id}", (KeywordId id) => { });
    }
}