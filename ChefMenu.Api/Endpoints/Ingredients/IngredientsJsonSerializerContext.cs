using System.Text.Json.Serialization;
using ChefMenu.Api.Endpoints.Ingredients.Post;
using ChefMenu.Api.JsonSerialization.JsonSerializerContexts;
using ChefMenu.Application.Features.Ingredients.Commands.Create.Results;

namespace ChefMenu.Api.Endpoints.Ingredients;

[JsonSerializable(typeof(PostIngredientRequest))]
[JsonSerializable(typeof(IngredientCreatedResult))]
[JsonSerializable(typeof(IngredientNameAlreadyExists))]
internal partial class IngredientsJsonSerializerContext : ApiJsonSerializerContext;
