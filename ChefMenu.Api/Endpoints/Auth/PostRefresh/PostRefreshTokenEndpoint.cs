using ChefMenu.Api.Endpoints.Core;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.BearerToken;
using Microsoft.AspNetCore.Http.HttpResults;

namespace ChefMenu.Api.Endpoints.Auth.PostRefresh;

public struct PostRefreshTokenEndpoint : IEndpoint
{
    public static IEndpointConventionBuilder Map(IEndpointRouteBuilder builder)
    {
        return builder.MapPost("refresh", async Task<Results<Ok, UnauthorizedHttpResult>> (
            HttpContext httpContext) =>
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