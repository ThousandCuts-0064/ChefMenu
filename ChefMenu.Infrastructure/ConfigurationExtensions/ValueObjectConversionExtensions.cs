using ChefMenu.Domain.Features.Core.ValueObjects;
using ChefMenu.Infrastructure.Conversions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ChefMenu.Infrastructure.ConfigurationExtensions;

internal static class ValueObjectConversionExtensions
{
    public static PropertyBuilder<TValueObject> IsValueObject<TValueObject, TValue>(
        this PropertyBuilder<TValueObject> builder)
        where TValueObject : struct, IValueObject<TValueObject, TValue>
        where TValue : notnull
    {
        return builder.HasConversion(
            ValueObjectConverter<TValueObject, TValue>.Converter,
            ValueObjectComparer<TValueObject, TValue>.Comparer);
    }

    public static ModelConfigurationBuilder HasValueObject<TValueObject, TValue>(
        this ModelConfigurationBuilder builder)
        where TValueObject : struct, IValueObject<TValueObject, TValue>
        where TValue : notnull
    {
        builder.Properties<TValueObject>().HaveConversion<
            ValueObjectConverter<TValueObject, TValue>,
            ValueObjectComparer<TValueObject, TValue>>();

        return builder;
    }
}