using System.Security.Claims;
using ChefMenu.Api.Endpoints.Core;
using ChefMenu.Api.Extensions;
using ChefMenu.Application.Core.Mediators;
using ChefMenu.Application.Features.Auth.Queries.Login;
using ChefMenu.Application.Features.Auth.Queries.Login.Results;
using Microsoft.AspNetCore.Authentication.BearerToken;
using Microsoft.AspNetCore.Http.HttpResults;

namespace ChefMenu.Api.Endpoints.Auth.Login;

public struct LoginUserEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder builder)
    {
        builder.MapPost("login", async (
            IFetcher fetcher,
            LoginUserRequest request,
            CancellationToken ct) =>
        {
            var result = await fetcher.FetchAsync(new LoginUserQuery
            {
                Username = request.Username.Require(),
                Password = request.Password.Require()
            }, ct);

            return result.MapToHttpResults(
                MapCorrectCredentials,
                MapIncorrectCredentials);
        });
    }

    private static SignInHttpResult MapCorrectCredentials(CorrectUserCredentialsResult result)
    {
        var principal = new ClaimsPrincipal(new ClaimsIdentity(
        [
            new Claim(
                ClaimTypes.NameIdentifier,
                result.Id.ToString(),
                ClaimValueTypes.Integer32),
            new Claim(
                ClaimTypes.Name,
                result.Username,
                ClaimValueTypes.String),
            new Claim(
                ClaimTypes.Role,
                result.Role.ToString(),
                ClaimValueTypes.String)
        ], BearerTokenDefaults.AuthenticationScheme));

        return TypedResults.SignIn(principal);
    }

    private static UnauthorizedHttpResult MapIncorrectCredentials(IncorrectUserCredentialsResult result)
    {
        return TypedResults.Unauthorized();
    }
}