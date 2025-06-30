using System.Diagnostics.CodeAnalysis;
using ChefMenu.Domain.Constants;
using ChefMenu.Domain.Errors;
using ChefMenu.Domain.Exceptions;
using ChefMenu.Domain.Features.Core.ValueObjects;

namespace ChefMenu.Domain.Features.Recipes.ValueObjects;

public readonly record struct RecipeId : IKeyObject<RecipeId, int>
{
    public static string ErrorCode => ErrorCodes.InvalidRecipeId;
    public static string ErrorMessage => "Recipe Id must be positive.";

    public int Value { get; }

    private RecipeId(int value) => Value = value;

    public static RecipeId Create(int value)
    {
        return value >= Constraints.MinId
            ? new RecipeId(value)
            : ValueObjectException.Throw<RecipeId>(value);
    }

    public static bool TryCreate(int value, out RecipeId result)
    {
        var canCreate = value >= Constraints.MinId;

        result = canCreate ? new RecipeId(value) : default;

        return canCreate;
    }

    public static RecipeId CreateUnchecked(int value) => new(value);

    public override string ToString() => Value.ToString();

    public static RecipeId Parse(string s, IFormatProvider? provider)
    {
        return Create(int.Parse(s, provider));
    }

    public static bool TryParse([NotNullWhen(true)] string? s, IFormatProvider? provider, out RecipeId result)
    {
        result = default;

        return int.TryParse(s, provider, out var value) && TryCreate(value, out result);
    }

    public static implicit operator int(RecipeId valueObject) => valueObject.Value;
}