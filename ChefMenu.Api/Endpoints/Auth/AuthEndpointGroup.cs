using ChefMenu.Api.Endpoints.Auth.Login;
using ChefMenu.Api.Endpoints.Auth.Register;
using ChefMenu.Api.Endpoints.Core;

namespace ChefMenu.Api.Endpoints.Auth;

public struct AuthEndpointGroup : IEndpointGroup
{
    public static void Map(RouteGroupBuilder builder) => builder
        .MapGroup("/auth")
        .AllowAnonymous()
        .MapEndpoint<RegisterUserEndpoint>()
        .MapEndpoint<LoginUserEndpoint>();
}