﻿using ChefMenu.Api.Endpoints.Core;
using ChefMenu.Api.Extensions;
using ChefMenu.Application.Core.Mediators;
using ChefMenu.Application.Features.Auth.Queries.Login;
using ChefMenu.Application.Features.Auth.Queries.Login.Results;
using Microsoft.AspNetCore.Http.HttpResults;

namespace ChefMenu.Api.Endpoints.Auth.PostLogin;

public struct PostLoginUserEndpoint : IEndpoint
{
    public static IEndpointConventionBuilder Map(IEndpointRouteBuilder builder)
    {
        return builder.MapPost("login", async (
            PostLoginUserRequest request,
            IFetcher fetcher,
            CancellationToken ct) =>
        {
            var result = await fetcher.FetchAsync(new LoginUserQuery
            {
                Username = request.Username,
                Password = request.Password
            }, ct);

            return result.MapToHttpResults(
                MapCorrectCredentials,
                MapIncorrectCredentials);
        });
    }

    private static SignInHttpResult MapCorrectCredentials(CorrectUserCredentialsResult result)
    {
        return TypedResults.Extensions.SignInWithBearer(
            result.Id,
            result.Username,
            result.Role);
    }

    private static UnauthorizedHttpResult MapIncorrectCredentials(IncorrectUserCredentialsResult result)
    {
        return TypedResults.Unauthorized();
    }
}