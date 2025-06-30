using ChefMenu.Api.Endpoints.Core;
using ChefMenu.Domain.Features.Keywords.ValueObjects;

namespace ChefMenu.Api.Endpoints.Keywords.Patch;

public struct PatchKeywordsEndpoint : IEndpoint
{
    public static IEndpointConventionBuilder Map(IEndpointRouteBuilder builder)
    {
        return builder.MapPatch("/{id}", (KeywordId id) => { });
    }
}