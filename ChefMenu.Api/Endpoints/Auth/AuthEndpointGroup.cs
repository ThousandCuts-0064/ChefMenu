using ChefMenu.Api.Endpoints.Auth.PostLogin;
using ChefMenu.Api.Endpoints.Auth.PostRefresh;
using ChefMenu.Api.Endpoints.Auth.PostRegister;
using ChefMenu.Api.Endpoints.Core;

namespace ChefMenu.Api.Endpoints.Auth;

public struct AuthEndpointGroup : IEndpointGroup
{
    public static RouteGroupBuilder Map(RouteGroupBuilder builder) => builder
        .MapGroup("/auth")
        .AllowAnonymous()
        .MapEndpoint<PostRegisterUserEndpoint>()
        .MapEndpoint<PostLoginUserEndpoint>()
        .MapEndpoint<PostRefreshTokenEndpoint>();
}