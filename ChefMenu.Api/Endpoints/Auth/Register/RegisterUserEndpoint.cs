using ChefMenu.Api.Endpoints.Core;
using ChefMenu.Api.Extensions;
using ChefMenu.Application.Core.Mediators;
using ChefMenu.Application.Features.Auth.Commands.Register;
using ChefMenu.Application.Features.Auth.Commands.Register.Results;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace ChefMenu.Api.Endpoints.Auth.Register;

public struct RegisterUserEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder builder)
    {
        builder.MapPost("/register", async (
            IExecutor executor,
            RegisterUserRequest request,
            CancellationToken ct) =>
        {
            var result = await executor.ExecuteAsync(new RegisterUserCommand
            {
                Username = request.Username,
                Email = request.Email,
                Password = request.Password,
                DisplayName = request.DisplayName,
            }, ct);

            return result.MapToHttpResults(
                MapCreated,
                MapAlreadyExists);
        });
    }

    private static SignInHttpResult MapCreated(UserCreatedResult result)
    {
        return TypedResults.Extensions.SignInWithBearer(
            result.Id,
            result.Username,
            result.Role);
    }

    private static ProblemHttpResult MapAlreadyExists(UsernameAlreadyExistsResult result)
    {
        return TypedResults.Problem(new ProblemDetails
        {
            Status = StatusCodes.Status409Conflict,
            Title = result.ErrorCode,
            Detail = result.ErrorMessage
        });
    }
}