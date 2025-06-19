using ChefMenu.Domain.Features.Categories.ValueObjects;
using ChefMenu.Domain.Features.Core;
using ChefMenu.Domain.Features.Kitchenwares;
using ChefMenu.Domain.Features.Kitchenwares.ValueObjects;
using ChefMenu.Domain.Features.Products;
using ChefMenu.Domain.Features.Products.ValueObjects;

namespace ChefMenu.Domain.Features.Categories;

public sealed class Category : ContentEntity<CategoryId, CategoryName>
{
    public KitchenwareId? KitchenwareId { get; init; }
    public ProductId? ProductId { get; init; }

    public Kitchenware? Kitchenware { get; init; }
    public Product? Product { get; init; }
}