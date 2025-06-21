using ChefMenu.Domain.Constants;
using ChefMenu.Domain.Errors;
using ChefMenu.Domain.Exceptions;
using ChefMenu.Domain.Features.Core.ValueObjects;

namespace ChefMenu.Domain.Features.Shared.ValueObjects;

public readonly record struct Quantity : IValueObject<Quantity, int>
{
    public const int Min = 1;

    public static string ErrorCode => ErrorCodes.InvalidQuantity;
    public static string ErrorMessage => "Quantity must be positive.";

    public int Value { get; }

    private Quantity(int value) => Value = value;

    public static Quantity Create(int value)
    {
        return value >= Min
            ? new Quantity(value)
            : ValueObjectException.Throw<Quantity>(value);
    }

    public static bool TryCreate(int value, out Quantity result)
    {
        var canCreate = value >= Constraints.MinId;

        result = canCreate ? new Quantity(value) : default;

        return canCreate;
    }

    public static Quantity CreateUnchecked(int value) => new(value);

    public override string ToString() => Value.ToString();

    public static implicit operator int(Quantity valueObject) => valueObject.Value;
}