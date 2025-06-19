using ChefMenu.Application.Core.Features;
using ChefMenu.Application.Core.Mediators;
using ChefMenu.Application.Features.Auth.Commands.Register;
using ChefMenu.Application.Features.Auth.Queries.Login;
using Microsoft.Extensions.DependencyInjection;

namespace ChefMenu.Application.Features.Auth;

public struct AuthFeature : IFeature
{
    public static IServiceCollection Add(IServiceCollection services) => services
        .AddCommand<RegisterUserCommand, RegisterUserCommandHandler>()
        .AddQuery<LoginUserQuery, LoginUserQueryHandler>();
}