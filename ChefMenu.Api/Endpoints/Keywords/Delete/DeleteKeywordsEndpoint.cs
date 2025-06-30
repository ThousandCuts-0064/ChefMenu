using ChefMenu.Api.Endpoints.Core;
using ChefMenu.Domain.Features.Keywords.ValueObjects;

namespace ChefMenu.Api.Endpoints.Keywords.Delete;

public struct DeleteKeywordsEndpoint : IEndpoint
{
    public static IEndpointConventionBuilder Map(IEndpointRouteBuilder builder)
    {
        return builder.MapDelete("/{id}", (KeywordId id) => { });
    }
}