using ChefMenu.Application.Core.Features;
using ChefMenu.Application.Core.Mediators;
using ChefMenu.Application.Features.Categories.Commands.Create;
using Microsoft.Extensions.DependencyInjection;

namespace ChefMenu.Application.Features.Categories;

public struct CategoriesFeature : IFeature
{
    public static IServiceCollection Add(IServiceCollection services) => services
        .AddCommand<CreateCategoryCommand, CreateCategoryCommandHandler>();
}