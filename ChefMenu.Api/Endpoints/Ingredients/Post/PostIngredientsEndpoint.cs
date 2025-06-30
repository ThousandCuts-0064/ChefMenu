using System.Security.Claims;
using ChefMenu.Api.Endpoints.Core;
using ChefMenu.Api.Extensions;
using ChefMenu.Application.Core.Mediators;
using ChefMenu.Application.Features.Ingredients.Commands.Create;

namespace ChefMenu.Api.Endpoints.Ingredients.Post;

public struct PostIngredientsEndpoint : IEndpoint
{
    public static IEndpointConventionBuilder Map(IEndpointRouteBuilder builder)
    {
        return builder.MapPost("", async (
            ClaimsPrincipal principal,
            PostIngredientsRequest request,
            IExecutor executor,
            CancellationToken ct) =>
        {
            var result = await executor.ExecuteAsync(new CreateIngredientCommand
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