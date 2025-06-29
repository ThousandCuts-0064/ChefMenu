using System.Security.Claims;
using ChefMenu.Api.Endpoints.Core;
using ChefMenu.Api.Extensions;
using ChefMenu.Application.Core.Mediators;
using ChefMenu.Application.Features.Recipes.Commands.Create;

namespace ChefMenu.Api.Endpoints.Recipes.Post;

public struct PostRecipeEndpoint : IEndpoint
{
    public static IEndpointConventionBuilder Map(IEndpointRouteBuilder builder)
    {
        return builder.MapPost("", async (
            ClaimsPrincipal principal,
            PostRecipeRequest request,
            IExecutor executor,
            CancellationToken ct) =>
        {
            var result = await executor.ExecuteAsync(new CreateRecipeCommand
            {
                CreateById = principal.GetUserId(),
                Name = request.Name,
                DisplayName = request.DisplayName,
                Content = request.Content,
            }, ct);

            return result.MapToHttpResults(
                TypedResults.Ok,
                TypedResults.Conflict);
        });
    }
}