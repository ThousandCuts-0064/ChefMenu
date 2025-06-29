using ChefMenu.Api.Constants;
using ChefMenu.Api.Endpoints.Core;
using ChefMenu.Api.Endpoints.Users.Get;
using ChefMenu.Api.Endpoints.Users.GetSearch;
using ChefMenu.Api.Endpoints.Users.PatchRole;

namespace ChefMenu.Api.Endpoints.Users;

public struct UsersEndpointGroup : IEndpointGroup
{
    public static RouteGroupBuilder Map(RouteGroupBuilder builder) => builder
        .MapGroup("/users")
        .MapEndpoint<GetSearchUsersEndpoint>(x => x.AllowAnonymous())
        .MapEndpoint<GetUserEndpoint>()
        .MapEndpoint<PatchUserRoleEndpoint>(x => x.RequireAuthorization(AuthPolicies.ModeratorPlus));
}