using System.Text.Json.Serialization;
using ChefMenu.Api.Endpoints.Categories.Post;
using ChefMenu.Api.JsonSerialization.JsonSerializerContexts;
using ChefMenu.Application.Features.Categories.Commands.Create.Results;
using ChefMenu.Application.Features.Categories.Queries.Get.Results;

namespace ChefMenu.Api.Endpoints.Categories;

[JsonSerializable(typeof(PostCategoryRequest))]
[JsonSerializable(typeof(CategoryCreatedResult))]
[JsonSerializable(typeof(CategoryNameAlreadyExists))]
[JsonSerializable(typeof(CategoryResult))]
[JsonSerializable(typeof(CategoryIdNotFoundResult))]
internal partial class CategoriesJsonSerializerContext : ApiJsonSerializerContext;
