using ChefMenu.Application.Core.Features;
using ChefMenu.Application.Core.Mediators;
using ChefMenu.Application.Features.Auth;
using ChefMenu.Application.Features.Categories;
using ChefMenu.Application.Features.Ingredients;
using ChefMenu.Application.Features.Keywords;
using ChefMenu.Application.Features.Kitchenwares;
using ChefMenu.Application.Features.Me;
using ChefMenu.Application.Features.RecipeCollections;
using ChefMenu.Application.Features.Recipes;
using ChefMenu.Application.Features.Users;
using ChefMenu.Application.Services.DateTimeProvider;
using ChefMenu.Application.Services.Passwords;
using Microsoft.Extensions.DependencyInjection;

namespace ChefMenu.Application.DependencyInjection;

public static class ApplicationServiceCollectionExtensions
{
    public static IServiceCollection AddApplication(this IServiceCollection services, ApplicationOptions options)
    {
        services.AddOptions<PasswordHasherOptions>()
            .BindConfiguration(options.PasswordHasher)
            .ValidateDataAnnotations()
            .ValidateOnStart();

        return services
            .AddMediator()
            .AddSingleton<IDateTimeProvider>(new DateTimeProvider())
            .AddScoped<IPasswordHasher, PasswordHasher>()
            .AddFeature<AuthFeature>()
            .AddFeature<UsersFeature>()
            .AddFeature<MeFeature>()
            .AddFeature<CategoriesFeature>()
            .AddFeature<IngredientsFeature>()
            .AddFeature<KitchenwaresFeature>()
            .AddFeature<KeywordsFeature>()
            .AddFeature<RecipesFeature>()
            .AddFeature<RecipeCollectionsFeature>();
    }
}