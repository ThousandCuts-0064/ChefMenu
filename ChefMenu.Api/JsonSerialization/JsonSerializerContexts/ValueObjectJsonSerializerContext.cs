using System.Text.Json.Serialization;
using ChefMenu.Application.ValueObjects;
using ChefMenu.Domain.Features.Categories.ValueObjects;
using ChefMenu.Domain.Features.Comments.ValueObjects;
using ChefMenu.Domain.Features.Ingredients.ValueObjects;
using ChefMenu.Domain.Features.Keywords.ValueObjects;
using ChefMenu.Domain.Features.Kitchenwares.ValueObjects;
using ChefMenu.Domain.Features.RecipeCollections.ValueObjects;
using ChefMenu.Domain.Features.Recipes.ValueObjects;
using ChefMenu.Domain.Features.SystemActionHistories.ValueObjects;
using ChefMenu.Domain.Features.SystemConfigs.ValueObjects;
using ChefMenu.Domain.Features.UserFeedbacks.ValueObjects;
using ChefMenu.Domain.Features.Users.ValueObjects;

namespace ChefMenu.Api.JsonSerialization.JsonSerializerContexts;

[JsonSerializable(typeof(PageSize?))]
[JsonSerializable(typeof(EntityName))]
[JsonSerializable(typeof(UserId))]
[JsonSerializable(typeof(Username?))]
[JsonSerializable(typeof(CommentId))]
[JsonSerializable(typeof(RecipeId))]
[JsonSerializable(typeof(RecipeName?))]
[JsonSerializable(typeof(RecipeCollectionId))]
[JsonSerializable(typeof(RecipeCollectionName?))]
[JsonSerializable(typeof(UserFeedbackId))]
[JsonSerializable(typeof(CategoryId))]
[JsonSerializable(typeof(CategoryName?))]
[JsonSerializable(typeof(IngredientId))]
[JsonSerializable(typeof(IngredientName?))]
[JsonSerializable(typeof(KitchenwareId))]
[JsonSerializable(typeof(KitchenwareName?))]
[JsonSerializable(typeof(KeywordId))]
[JsonSerializable(typeof(KeywordName?))]
[JsonSerializable(typeof(SystemConfigKey))]
internal partial class ValueObjectJsonSerializerContext : ApiJsonSerializerContext;