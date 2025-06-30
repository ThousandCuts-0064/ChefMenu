using ChefMenu.Api.Endpoints.Core;
using ChefMenu.Domain.Features.Categories.ValueObjects;

namespace ChefMenu.Api.Endpoints.Categories.Delete;

public struct DeleteCategoriesEndpoint : IEndpoint
{
    public static IEndpointConventionBuilder Map(IEndpointRouteBuilder builder)
    {
        return builder.MapDelete("/{id}", (CategoryId id) => { });
    }
}