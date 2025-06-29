using ChefMenu.Domain.Enums;
using ChefMenu.Domain.Features.Categories.ValueObjects;
using ChefMenu.Domain.Features.Core;
using ChefMenu.Domain.Features.Ingredients;
using ChefMenu.Domain.Features.Kitchenwares;

namespace ChefMenu.Domain.Features.Categories;

public sealed class Category : ContentEntity<CategoryId, CategoryName>
{
    public required CategoryType Type { get; init; }

    public HashSet<Kitchenware> Kitchenwares { get; set; } = [];
    public HashSet<Ingredient> Ingredients { get; set; } = [];
}