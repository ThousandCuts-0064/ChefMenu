using ChefMenu.Api.Endpoints.Core;
using ChefMenu.Domain.Features.Categories.ValueObjects;

namespace ChefMenu.Api.Endpoints.Categories.Patch;

public struct PatchCategoriesEndpoint : IEndpoint
{
    public static IEndpointConventionBuilder Map(IEndpointRouteBuilder builder)
    {
        return builder.MapPatch("/{id}", (CategoryId id) => { });
    }
}