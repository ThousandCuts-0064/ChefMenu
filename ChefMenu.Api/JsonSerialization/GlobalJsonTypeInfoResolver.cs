using System.Text.Json.Serialization.Metadata;
using ChefMenu.Api.Endpoints.Auth;
using ChefMenu.Api.Endpoints.Categories;
using ChefMenu.Api.Endpoints.Ingredients;
using ChefMenu.Api.Endpoints.Keywords;
using ChefMenu.Api.Endpoints.Kitchenwares;
using ChefMenu.Api.Endpoints.Me;
using ChefMenu.Api.Endpoints.RecipeCollections;
using ChefMenu.Api.Endpoints.Recipes;
using ChefMenu.Api.Endpoints.Users;
using ChefMenu.Api.JsonSerialization.JsonSerializerContexts;

namespace ChefMenu.Api.JsonSerialization;

public static class GlobalJsonTypeInfoResolver
{
    public static IJsonTypeInfoResolver Instance { get; } = JsonTypeInfoResolver.Combine(
        ResultJsonSerializerContext.Default,
        EnumJsonSerializerContext.Default,
        ValueObjectJsonSerializerContext.Default,
        AuthJsonSerializerContext.Default,
        UsersJsonSerializerContext.Default,
        MeJsonSerializerContext.Default,
        CategoriesJsonSerializerContext.Default,
        IngredientsJsonSerializerContext.Default,
        KitchenwaresJsonSerializerContext.Default,
        KeywordsJsonSerializerContext.Default,
        RecipesJsonSerializerContext.Default,
        RecipeCollectionsJsonSerializerContext.Default);
}