using System.Text.Json.Serialization;
using ChefMenu.Api.Endpoints.Recipes.Post;
using ChefMenu.Api.JsonSerialization.JsonSerializerContexts;
using ChefMenu.Application.Features.Recipes.Commands.Create.Results;

namespace ChefMenu.Api.Endpoints.Recipes;

[JsonSerializable(typeof(PostRecipeRequest))]
[JsonSerializable(typeof(RecipeCreatedResult))]
[JsonSerializable(typeof(RecipeNameAlreadyExists))]
internal partial class RecipesJsonSerializerContext : ApiJsonSerializerContext;
