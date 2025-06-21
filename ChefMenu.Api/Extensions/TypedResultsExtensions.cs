using System.Security.Claims;
using ChefMenu.Domain.Enums;
using ChefMenu.Domain.Features.Users.ValueObjects;
using Microsoft.AspNetCore.Authentication.BearerToken;
using Microsoft.AspNetCore.Http.HttpResults;

namespace ChefMenu.Api.Extensions;

public static class TypedResultsExtensions
{
    public static SignInHttpResult SignInWithBearer(
        this IResultExtensions _,
        UserId id,
        Username username,
        UserRole role)
    {
        return TypedResults.SignIn(new ClaimsPrincipal(new ClaimsIdentity(
        [
            new Claim(
                ClaimTypes.NameIdentifier,
                id.ToString(),
                ClaimValueTypes.Integer32),
            new Claim(
                ClaimTypes.Name,
                username,
                ClaimValueTypes.String),
            new Claim(
                ClaimTypes.Role,
                role.ToString(),
                ClaimValueTypes.String)
        ], BearerTokenDefaults.AuthenticationScheme)));
    }
}