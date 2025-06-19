using ChefMenu.Domain.Enums;
using ChefMenu.Domain.Features.Core;
using ChefMenu.Domain.Features.Products.ValueObjects;
using ChefMenu.Domain.Features.Recipes;
using ChefMenu.Domain.Features.Recipes.ValueObjects;
using ChefMenu.Domain.Features.Shared.ValueObjects;

namespace ChefMenu.Domain.Features.Products;

public sealed class ProductRecipe : JoinEntity
{
    public ProductId ProductId { get; init; }
    public RecipeId RecipeId { get; init; }

    public required Quantity Quantity { get; set; }
    public required MeasurementUnit MeasurementUnit { get; set; }

    public Product Product { get; init; } = null!;
    public Recipe Recipe { get; init; } = null!;
}
