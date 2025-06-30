using System.Security.Claims;
using ChefMenu.Api.Endpoints.Core;
using ChefMenu.Api.Extensions;
using ChefMenu.Application.Core.Mediators;
using ChefMenu.Application.Features.Kitchenwares.Commands.Create;

namespace ChefMenu.Api.Endpoints.Kitchenwares.Post;

public struct PostKitchenwaresEndpoint : IEndpoint
{
    public static IEndpointConventionBuilder Map(IEndpointRouteBuilder builder)
    {
        return builder.MapPost("", async (
            ClaimsPrincipal principal,
            PostKitchenwaresRequest request,
            IExecutor executor,
            CancellationToken ct) =>
        {
            var result = await executor.ExecuteAsync(new CreateKitchenwareCommand
            {
                CreateById = principal.GetUserId(),
                Name = request.Name,
                DisplayName = request.DisplayName,
            }, ct);

            return result.MapToHttpResults(
                TypedResults.Ok,
                TypedResults.Conflict);
        });
    }
}