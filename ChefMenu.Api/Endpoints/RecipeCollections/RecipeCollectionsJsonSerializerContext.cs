using System.Text.Json.Serialization;
using ChefMenu.Api.Endpoints.RecipeCollections.Post;
using ChefMenu.Api.JsonSerialization.JsonSerializerContexts;
using ChefMenu.Application.Features.RecipeCollections.Commands.Create.Results;

namespace ChefMenu.Api.Endpoints.RecipeCollections;

[JsonSerializable(typeof(PostRecipeCollectionRequest))]
[JsonSerializable(typeof(RecipeCollectionCreatedResult))]
[JsonSerializable(typeof(RecipeCollectionNameAlreadyExists))]
internal partial class RecipeCollectionsJsonSerializerContext : ApiJsonSerializerContext;
