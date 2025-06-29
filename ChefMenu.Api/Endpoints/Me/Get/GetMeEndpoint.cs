using System.Security.Claims;
using ChefMenu.Api.Endpoints.Core;
using ChefMenu.Api.Extensions;
using ChefMenu.Application.Core.Mediators;
using ChefMenu.Application.Features.Me.Queries.Get;

namespace ChefMenu.Api.Endpoints.Me.Get;

public struct GetMeEndpoint : IEndpoint
{
    public static IEndpointConventionBuilder Map(IEndpointRouteBuilder builder)
    {
        return builder.MapGet("", async (
            ClaimsPrincipal principal,
            IFetcher fetcher,
            CancellationToken ct) =>
        {
            var result = await fetcher.FetchAsync(new GetMeQuery
            {
                Id = principal.GetUserId()
            }, ct);

            return result.MapToHttpResults(
                TypedResults.Ok,
                TypedResults.NotFound);
        });
    }
}