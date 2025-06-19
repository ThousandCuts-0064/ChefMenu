using ChefMenu.Domain.Features.Core.ValueObjects;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ChefMenu.Infrastructure.Conversions;

internal sealed class ValueObjectConverter<TValueObject, TValue> : ValueConverter<TValueObject, TValue>
    where TValueObject : struct, IValueObject<TValueObject, TValue>
    where TValue : notnull
{
    public static ValueObjectConverter<TValueObject, TValue> Converter { get; } = new();

    public ValueObjectConverter() : base(
        x => x.Value,
        x => CreateUnchecked(x)) { }

    private static TValueObject CreateUnchecked(TValue value) => TValueObject.CreateUnchecked(value);
}

internal sealed class ValueObjectComparer<TValueObject, TValue> : ValueComparer<TValueObject>
    where TValueObject : struct, IValueObject<TValueObject, TValue>
    where TValue : notnull
{
    public static ValueObjectComparer<TValueObject, TValue> Comparer { get; } = new();

    public ValueObjectComparer() : base(
        (x, y) => x.Equals(y),
        x => x.GetHashCode()) { }
}