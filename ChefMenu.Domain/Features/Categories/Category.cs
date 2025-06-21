using ChefMenu.Domain.Features.Categories.ValueObjects;
using ChefMenu.Domain.Features.Core;
using ChefMenu.Domain.Features.Ingredients;
using ChefMenu.Domain.Features.Ingredients.ValueObjects;
using ChefMenu.Domain.Features.Kitchenwares;
using ChefMenu.Domain.Features.Kitchenwares.ValueObjects;

namespace ChefMenu.Domain.Features.Categories;

public sealed class Category : ContentEntity<CategoryId, CategoryName>
{
    public KitchenwareId? KitchenwareId { get; init; }
    public IngredientId? IngredientId { get; init; }

    public Kitchenware? Kitchenware { get; init; }
    public Ingredient? Ingredient { get; init; }
}