using ChefMenu.Api.Endpoints.Core;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.BearerToken;
using Microsoft.AspNetCore.Http.HttpResults;

namespace ChefMenu.Api.Endpoints.Auth.Refresh;

public struct RefreshTokenEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder builder)
    {
        builder.MapPost("login", async Task<Results<Ok, UnauthorizedHttpResult>> (HttpContext httpContext) =>
        {
            var result = await httpContext.AuthenticateAsync(BearerTokenDefaults.AuthenticationScheme);

            if (!result.Succeeded)
            {
                return TypedResults.Unauthorized();
            }

            await httpContext.SignInAsync(
                BearerTokenDefaults.AuthenticationScheme,
                result.Principal!,
                result.Properties);

            return TypedResults.Ok();
        });
    }
}