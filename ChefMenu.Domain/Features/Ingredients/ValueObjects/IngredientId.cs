using ChefMenu.Domain.Constants;
using ChefMenu.Domain.Errors;
using ChefMenu.Domain.Exceptions;
using ChefMenu.Domain.Features.Core.ValueObjects;

namespace ChefMenu.Domain.Features.Ingredients.ValueObjects;

public readonly record struct IngredientId : IKeyObject<IngredientId, int>
{
    public static string ErrorCode => ErrorCodes.InvalidIngredientId;
    public static string ErrorMessage => "Ingredient Id must be positive.";

    public int Value { get; }

    private IngredientId(int value) => Value = value;

    public static IngredientId Create(int value)
    {
        return value >= Constraints.MinId
            ? new IngredientId(value)
            : ValueObjectException.Throw<IngredientId>(value);
    }

    public static bool TryCreate(int value, out IngredientId result)
    {
        var canCreate = value >= Constraints.MinId;

        result = canCreate ? new IngredientId(value) : default;

        return canCreate;
    }

    public static IngredientId CreateUnchecked(int value) => new(value);

    public override string ToString() => Value.ToString();

    public static implicit operator int(IngredientId valueObject) => valueObject.Value;
}