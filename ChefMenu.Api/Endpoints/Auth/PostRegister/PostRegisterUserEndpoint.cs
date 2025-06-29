using ChefMenu.Api.Endpoints.Core;
using ChefMenu.Api.Extensions;
using ChefMenu.Application.Core.Mediators;
using ChefMenu.Application.Features.Auth.Commands.Register;
using ChefMenu.Application.Features.Auth.Commands.Register.Results;
using Microsoft.AspNetCore.Http.HttpResults;

namespace ChefMenu.Api.Endpoints.Auth.PostRegister;

public struct PostRegisterUserEndpoint : IEndpoint
{
    public static IEndpointConventionBuilder Map(IEndpointRouteBuilder builder)
    {
        return builder.MapPost("/register", async (
            PostRegisterUserRequest request,
            IExecutor executor,
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

    private static Conflict<UsernameAlreadyExistsResult> MapAlreadyExists(UsernameAlreadyExistsResult result)
    {
        return TypedResults.Conflict(result);
    }
}