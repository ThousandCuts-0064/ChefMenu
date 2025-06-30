using ChefMenu.Api.Endpoints.Core;
using ChefMenu.Api.Extensions;
using ChefMenu.Application.Core.Mediators;
using ChefMenu.Application.Features.Categories.Queries.Get;
using ChefMenu.Domain.Features.Categories.ValueObjects;

namespace ChefMenu.Api.Endpoints.Categories.Get;

public struct GetCategoriesEndpoint : IEndpoint
{
    public static IEndpointConventionBuilder Map(IEndpointRouteBuilder builder)
    {
        return builder.MapGet("/{id}", async (
            CategoryId id,
            IFetcher fetcher,
            CancellationToken ct) =>
        {
            var result = await fetcher.FetchAsync(new GetCategoryQuery
            {
                Id = id
            }, ct);

            return result.MapToHttpResults(
                TypedResults.Ok,
                TypedResults.NotFound);
        });
    }
}