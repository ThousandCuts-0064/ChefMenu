using ChefMenu.Domain.Features.Categories;
using ChefMenu.Domain.Features.Core;
using ChefMenu.Domain.Features.Ingredients.ValueObjects;
using ChefMenu.Domain.Features.Recipes;

namespace ChefMenu.Domain.Features.Ingredients;

public sealed class Ingredient : ContentEntity<IngredientId, IngredientName>
{
    public HashSet<Category> Categories { get; set; } = [];
    public HashSet<Recipe> Recipes { get; set; } = [];
}