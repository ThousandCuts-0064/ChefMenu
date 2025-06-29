using ChefMenu.Application.Core.Features;
using ChefMenu.Application.Core.Mediators;
using ChefMenu.Application.Features.Users.Commands.UpdateRole;
using ChefMenu.Application.Features.Users.Queries.Get;
using ChefMenu.Application.Features.Users.Queries.Search;
using Microsoft.Extensions.DependencyInjection;

namespace ChefMenu.Application.Features.Users;

public struct UsersFeature : IFeature
{
    public static IServiceCollection Add(IServiceCollection services) => services
        .AddQuery<SearchUsersQuery, SearchUsersQueryHander>()
        .AddQuery<GetUserQuery, GetUserQueryHander>()
        .AddCommand<UpdateUserRoleCommand, UpdateUserRoleCommandHandler>();
}