using System.Security.Claims;
using ChefMenu.Api.Endpoints.Core;
using ChefMenu.Api.Extensions;
using ChefMenu.Application.Core.Mediators;
using ChefMenu.Application.Features.Users.Commands.UpdateRole;
using ChefMenu.Domain.Features.Users.ValueObjects;

namespace ChefMenu.Api.Endpoints.Users.PatchRole;

public struct PatchUserRoleEndpoint : IEndpoint
{
    public static IEndpointConventionBuilder Map(IEndpointRouteBuilder builder)
    {
        return builder.MapPatch("/{id}/role", async (
            ClaimsPrincipal principal,
            UserId id,
            PatchUserRoleRequest request,
            IExecutor executor,
            CancellationToken ct) =>
        {
            var result = await executor.ExecuteAsync(new UpdateUserRoleCommand
            {
                MeId = principal.GetUserId(),
                MeRole = principal.GetUserRole(),
                UserId = id,
                NewUserRole = request.Role
            }, ct);

            return result.MapToHttpResults(
                TypedResults.Ok,
                TypedResults.UnprocessableEntity,
                TypedResults.Extensions.ForbidSlim,
                TypedResults.NotFound);
        });
    }
}