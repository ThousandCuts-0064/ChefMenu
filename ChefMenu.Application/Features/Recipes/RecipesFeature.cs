using ChefMenu.Application.Core.Features;
using ChefMenu.Application.Core.Mediators;
using ChefMenu.Application.Features.Recipes.Commands.Create;
using Microsoft.Extensions.DependencyInjection;

namespace ChefMenu.Application.Features.Recipes;

public struct RecipesFeature : IFeature
{
    public static IServiceCollection Add(IServiceCollection services) => services
        .AddCommand<CreateRecipeCommand, CreateRecipeCommandHandler>();
}