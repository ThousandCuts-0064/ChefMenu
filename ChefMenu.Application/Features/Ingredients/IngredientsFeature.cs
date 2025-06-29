using ChefMenu.Application.Core.Features;
using ChefMenu.Application.Core.Mediators;
using ChefMenu.Application.Features.Ingredients.Commands.Create;
using Microsoft.Extensions.DependencyInjection;

namespace ChefMenu.Application.Features.Ingredients;

public struct IngredientsFeature : IFeature
{
    public static IServiceCollection Add(IServiceCollection services) => services
        .AddCommand<CreateIngredientCommand, CreateIngredientCommandHandler>();
}