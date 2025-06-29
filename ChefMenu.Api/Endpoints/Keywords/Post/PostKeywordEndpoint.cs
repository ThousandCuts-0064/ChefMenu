using System.Security.Claims;
using ChefMenu.Api.Endpoints.Core;
using ChefMenu.Api.Extensions;
using ChefMenu.Application.Core.Mediators;
using ChefMenu.Application.Features.Keywords.Commands.Create;

namespace ChefMenu.Api.Endpoints.Keywords.Post;

public struct PostKeywordEndpoint : IEndpoint
{
    public static IEndpointConventionBuilder Map(IEndpointRouteBuilder builder)
    {
        return builder.MapPost("", async (
            ClaimsPrincipal principal,
            PostKeywordRequest request,
            IExecutor executor,
            CancellationToken ct) =>
        {
            var result = await executor.ExecuteAsync(new CreateKeywordCommand
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