using System.Text.Json.Serialization;
using ChefMenu.Api.JsonSerialization.ValueObjectJsonConverters;
using ChefMenu.Domain.Features.Categories.ValueObjects;
using ChefMenu.Domain.Features.Comments.ValueObjects;
using ChefMenu.Domain.Features.Core.ValueObjects;
using ChefMenu.Domain.Features.Ingredients.ValueObjects;
using ChefMenu.Domain.Features.Keywords.ValueObjects;
using ChefMenu.Domain.Features.Kitchenwares.ValueObjects;
using ChefMenu.Domain.Features.RecipeCollections.ValueObjects;
using ChefMenu.Domain.Features.Recipes.ValueObjects;
using ChefMenu.Domain.Features.Shared.ValueObjects;
using ChefMenu.Domain.Features.SystemActionHistories.ValueObjects;
using ChefMenu.Domain.Features.SystemConfigs.ValueObjects;
using ChefMenu.Domain.Features.UserFeedbacks.ValueObjects;
using ChefMenu.Domain.Features.Users.ValueObjects;

namespace ChefMenu.Api.JsonSerialization;

public static class GlobalJsonConverters
{
    public static void AddGlobalJsonConverters(this ICollection<JsonConverter> converters)
    {
        // shared
        converters
            .AddIntObjectConverter<Quantity>()
            .AddIntObjectConverter<Rank>();

        converters
            .AddStringObjectConverter<Description>()
            .AddStringObjectConverter<DisplayName>()
            .AddStringObjectConverter<Text>();

        // specific
        converters
            .AddIntObjectConverter<UserId>()
            .AddIntObjectConverter<CategoryId>()
            .AddIntObjectConverter<CommentId>()
            .AddIntObjectConverter<KeywordId>()
            .AddIntObjectConverter<KitchenwareId>()
            .AddIntObjectConverter<IngredientId>()
            .AddIntObjectConverter<RecipeId>()
            .AddIntObjectConverter<RecipeCollectionId>()
            .AddIntObjectConverter<UserFeedbackId>();

        converters
            .AddStringObjectConverter<Username>()
            .AddStringObjectConverter<Password>()
            .AddStringObjectConverter<Email>()
            .AddStringObjectConverter<CategoryName>()
            .AddStringObjectConverter<KeywordName>()
            .AddStringObjectConverter<KitchenwareName>()
            .AddStringObjectConverter<IngredientName>()
            .AddStringObjectConverter<RecipeName>()
            .AddStringObjectConverter<RecipeCollectionName>()
            .AddStringObjectConverter<EntityName>()
            .AddStringObjectConverter<SystemConfigKey>();
    }

    private static ICollection<JsonConverter> AddIntObjectConverter<TValueObject>(
        this ICollection<JsonConverter> converters)
        where TValueObject : struct, IValueObject<TValueObject, int>
    {
        converters.Add(new RequiredValueObjectJsonConverter<TValueObject, int>());
        converters.Add(new OptionalValueObjectJsonConverter<TValueObject, int>());

        return converters;
    }

    private static ICollection<JsonConverter> AddStringObjectConverter<TValueObject>(
        this ICollection<JsonConverter> converters)
        where TValueObject : struct, IValueObject<TValueObject, string>
    {
        converters.Add(new RequiredStringObjectJsonConverter<TValueObject>());
        converters.Add(new OptionalStringObjectJsonConverter<TValueObject>());

        return converters;
    }
}