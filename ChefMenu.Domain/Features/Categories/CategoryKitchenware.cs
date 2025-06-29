using ChefMenu.Domain.Features.Categories.ValueObjects;
using ChefMenu.Domain.Features.Core;
using ChefMenu.Domain.Features.Kitchenwares;
using ChefMenu.Domain.Features.Kitchenwares.ValueObjects;

namespace ChefMenu.Domain.Features.Categories;

public sealed class CategoryKitchenware : JoinEntity
{
    public CategoryId CategoryId { get; init; }
    public KitchenwareId KitchenwareId { get; init; }

    public Category Category { get; init; } = null!;
    public Kitchenware Kitchenware { get; init; } = null!;

}
