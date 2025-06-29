using ChefMenu.Domain.Features.Categories.ValueObjects;
using ChefMenu.Domain.Features.Core;
using ChefMenu.Domain.Features.Ingredients;
using ChefMenu.Domain.Features.Ingredients.ValueObjects;

namespace ChefMenu.Domain.Features.Categories;

public sealed class CategoryIngredient : JoinEntity
{
    public CategoryId CategoryId { get; init; }
    public IngredientId IngredientId { get; init; }

    public Category Category { get; init; } = null!;
    public Ingredient Ingredient { get; init; } = null!;
}
