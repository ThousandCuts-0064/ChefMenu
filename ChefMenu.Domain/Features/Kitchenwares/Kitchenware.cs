using ChefMenu.Domain.Features.Categories;
using ChefMenu.Domain.Features.Core;
using ChefMenu.Domain.Features.Kitchenwares.ValueObjects;
using ChefMenu.Domain.Features.Recipes;

namespace ChefMenu.Domain.Features.Kitchenwares;

public sealed class Kitchenware : ContentEntity<KitchenwareId, KitchenwareName>
{
    public HashSet<Category> Categories { get; set; } = [];
    public HashSet<Recipe> Recipes { get; set; } = [];
}