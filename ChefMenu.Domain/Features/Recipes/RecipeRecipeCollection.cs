using ChefMenu.Domain.Features.Core;
using ChefMenu.Domain.Features.RecipeCollections;
using ChefMenu.Domain.Features.RecipeCollections.ValueObjects;
using ChefMenu.Domain.Features.Recipes.ValueObjects;

namespace ChefMenu.Domain.Features.Recipes;

public sealed class RecipeRecipeCollection : JoinEntity
{
    public RecipeId RecipeId { get; init; }
    public RecipeCollectionId RecipeCollectionId { get; init; }

    public Recipe Recipe { get; init; } = null!;
    public RecipeCollection RecipeCollection { get; init; } = null!;
}