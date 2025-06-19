using ChefMenu.Domain.Features.Core;
using ChefMenu.Domain.Features.Kitchenwares.ValueObjects;
using ChefMenu.Domain.Features.Recipes;
using ChefMenu.Domain.Features.Recipes.ValueObjects;

namespace ChefMenu.Domain.Features.Kitchenwares;

public sealed class KitchenwareRecipe : JoinEntity
{
    public KitchenwareId KitchenwareId { get; init; }
    public RecipeId RecipeId { get; init; }

    public Kitchenware Kitchenware { get; init; } = null!;
    public Recipe Recipe { get; init; } = null!;
}
