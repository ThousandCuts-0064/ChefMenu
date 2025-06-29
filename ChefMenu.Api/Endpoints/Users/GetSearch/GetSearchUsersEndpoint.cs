using System.Security.Claims;
using ChefMenu.Api.Endpoints.Core;
using ChefMenu.Api.Extensions;
using ChefMenu.Application.Core.Mediators;
using ChefMenu.Application.Features.Users.Queries.Search;
using ChefMenu.Application.ValueObjects;
using ChefMenu.Domain.Features.Users.ValueObjects;

namespace ChefMenu.Api.Endpoints.Users.GetSearch;

public struct GetSearchUsersEndpoint : IEndpoint
{
    public static IEndpointConventionBuilder Map(IEndpointRouteBuilder builder)
    {
        return builder.MapGet("/search", async (
            ClaimsPrincipal principal,
            Username? username,
            PageSize? pageSize,
            IFetcher fetcher,
            CancellationToken ct) =>
        {
            var result = await fetcher.FetchAsync(new SearchUsersQuery
            {
                MeRole = principal.GetUserRoleOrNull(),
                Username = username,
                PageSize = pageSize
            }, ct);

            return TypedResults.Ok(result);
        });
    }
}