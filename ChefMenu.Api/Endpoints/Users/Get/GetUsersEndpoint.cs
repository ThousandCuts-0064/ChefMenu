using System.Security.Claims;
using ChefMenu.Api.Endpoints.Core;
using ChefMenu.Api.Extensions;
using ChefMenu.Application.Core.Mediators;
using ChefMenu.Application.Features.Users.Queries.Get;
using ChefMenu.Domain.Features.Users.ValueObjects;

namespace ChefMenu.Api.Endpoints.Users.Get;

public struct GetUsersEndpoint : IEndpoint
{
    public static IEndpointConventionBuilder Map(IEndpointRouteBuilder builder)
    {
        return builder.MapGet("/{id}", async (
            ClaimsPrincipal principal,
            UserId id,
            IFetcher fetcher,
            CancellationToken ct) =>
        {
            var result = await fetcher.FetchAsync(new GetUserQuery
            {
                MeRole = principal.GetUserRoleOrNull(),
                Id = id
            }, ct);

            return result.MapToHttpResults(
                TypedResults.Ok,
                TypedResults.NotFound);
        });
    }
}