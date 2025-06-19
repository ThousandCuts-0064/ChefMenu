using ChefMenu.Domain.Features.Core;
using ChefMenu.Domain.Features.Keywords.ValueObjects;
using ChefMenu.Domain.Features.RecipeCollections;
using ChefMenu.Domain.Features.Recipes;

namespace ChefMenu.Domain.Features.Keywords;

public sealed class Keyword : NamedEntity<KeywordId, KeywordName>
{
    public HashSet<Recipe> Recipes { get; set; } = [];
    public HashSet<RecipeCollection> RecipeCollections { get; set; } = [];
}