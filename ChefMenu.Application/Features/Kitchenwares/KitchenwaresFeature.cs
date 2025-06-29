using ChefMenu.Application.Core.Features;
using ChefMenu.Application.Core.Mediators;
using ChefMenu.Application.Features.Kitchenwares.Commands.Create;
using Microsoft.Extensions.DependencyInjection;

namespace ChefMenu.Application.Features.Kitchenwares;

public struct KitchenwaresFeature : IFeature
{
    public static IServiceCollection Add(IServiceCollection services) => services
        .AddCommand<CreateKitchenwareCommand, CreateKitchenwareCommandHandler>();
}