using ChefMenu.Domain.Features.Core;
using ChefMenu.Domain.Features.Keywords.ValueObjects;
using ChefMenu.Domain.Features.Recipes;
using ChefMenu.Domain.Features.Recipes.ValueObjects;

namespace ChefMenu.Domain.Features.Keywords;

public sealed class KeywordRecipe : JoinEntity
{
    public KeywordId KeywordId { get; init; }
    public RecipeId RecipeId { get; init; }

    public Keyword Keyword { get; init; } = null!;
    public Recipe Recipe { get; init; } = null!;
}