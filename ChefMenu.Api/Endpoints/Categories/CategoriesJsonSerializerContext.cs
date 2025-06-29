using System.Text.Json.Serialization;
using ChefMenu.Api.Endpoints.Categories.Post;
using ChefMenu.Api.JsonSerialization.JsonSerializerContexts;
using ChefMenu.Application.Features.Categories.Commands.Create.Results;

namespace ChefMenu.Api.Endpoints.Categories;

[JsonSerializable(typeof(PostCategoryRequest))]
[JsonSerializable(typeof(CategoryCreatedResult))]
[JsonSerializable(typeof(CategoryNameAlreadyExists))]
internal partial class CategoriesJsonSerializerContext : ApiJsonSerializerContext;
