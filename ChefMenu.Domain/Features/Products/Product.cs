using ChefMenu.Domain.Features.Categories;
using ChefMenu.Domain.Features.Core;
using ChefMenu.Domain.Features.Products.ValueObjects;
using ChefMenu.Domain.Features.Recipes;

namespace ChefMenu.Domain.Features.Products;

public sealed class Product : ContentEntity<ProductId, ProductName>
{
    public HashSet<Category> Categories { get; set; } = [];
    public HashSet<Recipe> Recipes { get; set; } = [];
}