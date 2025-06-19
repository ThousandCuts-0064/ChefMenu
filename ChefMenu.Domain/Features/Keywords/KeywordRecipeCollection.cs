using ChefMenu.Domain.Features.Core;
using ChefMenu.Domain.Features.Keywords.ValueObjects;
using ChefMenu.Domain.Features.RecipeCollections;
using ChefMenu.Domain.Features.RecipeCollections.ValueObjects;

namespace ChefMenu.Domain.Features.Keywords;

public class KeywordRecipeCollection : JoinEntity
{
    public KeywordId KeywordId { get; init; }
    public RecipeCollectionId RecipeCollectionId { get; init; }

    public Keyword Keyword { get; init; } = null!;
    public RecipeCollection RecipeCollection { get; init; } = null!;
}