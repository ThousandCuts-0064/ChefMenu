using ChefMenu.Domain.Features.Comments;
using ChefMenu.Domain.Features.Core;
using ChefMenu.Domain.Features.Keywords;
using ChefMenu.Domain.Features.RecipeCollections.ValueObjects;
using ChefMenu.Domain.Features.Recipes;
using ChefMenu.Domain.Features.Shared.ValueObjects;

namespace ChefMenu.Domain.Features.RecipeCollections;

public sealed class RecipeCollection : ContentEntity<RecipeCollectionId, RecipeCollectionName>
{
    public Rank? Rank { get; set; }
    public bool IsPublic { get; set; }

    public HashSet<Keyword> Keywords { get; set; } = [];
    public HashSet<Recipe> Recipes { get; set; } = [];
    public HashSet<Comment> Comments { get; set; } = [];
}