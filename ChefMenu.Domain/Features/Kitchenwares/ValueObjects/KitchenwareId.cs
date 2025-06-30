using System.Diagnostics.CodeAnalysis;
using ChefMenu.Domain.Constants;
using ChefMenu.Domain.Errors;
using ChefMenu.Domain.Exceptions;
using ChefMenu.Domain.Features.Core.ValueObjects;

namespace ChefMenu.Domain.Features.Kitchenwares.ValueObjects;

public readonly record struct KitchenwareId : IKeyObject<KitchenwareId, int>
{
    public static string ErrorCode => ErrorCodes.InvalidKitchenwareId;
    public static string ErrorMessage => "Kitchenware Id must be positive.";

    public int Value { get; }

    private KitchenwareId(int value) => Value = value;

    public static KitchenwareId Create(int value)
    {
        return value >= Constraints.MinId
            ? new KitchenwareId(value)
            : ValueObjectException.Throw<KitchenwareId>(value);
    }

    public static bool TryCreate(int value, out KitchenwareId result)
    {
        var canCreate = value >= Constraints.MinId;

        result = canCreate ? new KitchenwareId(value) : default;

        return canCreate;
    }

    public static KitchenwareId CreateUnchecked(int value) => new(value);

    public override string ToString() => Value.ToString();

    public static KitchenwareId Parse(string s, IFormatProvider? provider)
    {
        return Create(int.Parse(s, provider));
    }

    public static bool TryParse([NotNullWhen(true)] string? s, IFormatProvider? provider, out KitchenwareId result)
    {
        result = default;

        return int.TryParse(s, provider, out var value) && TryCreate(value, out result);
    }

    public static implicit operator int(KitchenwareId valueObject) => valueObject.Value;
}