using ChefMenu.Domain.Enums;
using ChefMenu.Domain.Features.Core;
using ChefMenu.Domain.Features.Ingredients.ValueObjects;
using ChefMenu.Domain.Features.Recipes;
using ChefMenu.Domain.Features.Recipes.ValueObjects;
using ChefMenu.Domain.Features.Shared.ValueObjects;

namespace ChefMenu.Domain.Features.Ingredients;

public sealed class IngredientRecipe : JoinEntity
{
    public IngredientId IngredientId { get; init; }
    public RecipeId RecipeId { get; init; }

    public required Quantity Quantity { get; set; }
    public required MeasurementUnit MeasurementUnit { get; set; }

    public Ingredient Ingredient { get; init; } = null!;
    public Recipe Recipe { get; init; } = null!;
}
