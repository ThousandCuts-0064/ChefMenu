using ChefMenu.Domain.Enums;
using ChefMenu.Domain.Features.Categories;
using ChefMenu.Domain.Features.Categories.ValueObjects;
using ChefMenu.Domain.Features.Comments;
using ChefMenu.Domain.Features.Comments.ValueObjects;
using ChefMenu.Domain.Features.Core;
using ChefMenu.Domain.Features.Keywords;
using ChefMenu.Domain.Features.Keywords.ValueObjects;
using ChefMenu.Domain.Features.Kitchenwares;
using ChefMenu.Domain.Features.Kitchenwares.ValueObjects;
using ChefMenu.Domain.Features.Products;
using ChefMenu.Domain.Features.Products.ValueObjects;
using ChefMenu.Domain.Features.RecipeCollections;
using ChefMenu.Domain.Features.RecipeCollections.ValueObjects;
using ChefMenu.Domain.Features.Recipes;
using ChefMenu.Domain.Features.Recipes.ValueObjects;
using ChefMenu.Domain.Features.Users;
using ChefMenu.Domain.Features.Users.ValueObjects;

namespace ChefMenu.Domain.Features.UserActions;

public sealed class UserAction : JoinEntity
{
    public required UserActionType Type { get; init; }

    public UserId? ChefId { get; init; }
    public ProductId? ProductId { get; init; }
    public KitchenwareId? KitchenwareId { get; init; }
    public CategoryId? CategoryId { get; init; }
    public KeywordId? KeywordId { get; init; }
    public RecipeId? RecipeId { get; init; }
    public RecipeCollectionId? RecipeCollectionId { get; init; }
    public CommentId? CommentId { get; init; }

    public User? Chef { get; init; }
    public Product? Product { get; init; }
    public Kitchenware? Kitchenware { get; init; }
    public Category? Category { get; init; }
    public Keyword? Keyword { get; init; }
    public Recipe? Recipe { get; init; }
    public RecipeCollection? RecipeCollection { get; init; }
    public Comment? Comment { get; init; }
}