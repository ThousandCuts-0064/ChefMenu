using System.Text.Json;
using ChefMenu.Domain.Features.Comments;
using ChefMenu.Domain.Features.Core;
using ChefMenu.Domain.Features.Ingredients;
using ChefMenu.Domain.Features.Keywords;
using ChefMenu.Domain.Features.Kitchenwares;
using ChefMenu.Domain.Features.Recipes.ValueObjects;
using ChefMenu.Domain.Features.Shared.ValueObjects;

namespace ChefMenu.Domain.Features.Recipes;

public sealed class Recipe : ContentEntity<RecipeId, RecipeName>
{
    public JsonElement Content { get; set; }
    public Rank? Rank { get; set; }
    public bool IsPublic { get; set; }

    public HashSet<Kitchenware> Kitchenwares { get; set; } = [];
    public HashSet<IngredientRecipe> IngredientRecipes { get; set; } = [];
    public HashSet<Ingredient> Ingredients { get; set; } = [];
    public HashSet<Keyword> Keywords { get; set; } = [];
    public HashSet<Comment> Comments { get; set; } = [];
}