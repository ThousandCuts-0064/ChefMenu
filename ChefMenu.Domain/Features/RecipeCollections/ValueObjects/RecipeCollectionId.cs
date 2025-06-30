using System.Diagnostics.CodeAnalysis;
using ChefMenu.Domain.Constants;
using ChefMenu.Domain.Errors;
using ChefMenu.Domain.Exceptions;
using ChefMenu.Domain.Features.Core.ValueObjects;

namespace ChefMenu.Domain.Features.RecipeCollections.ValueObjects;

public readonly record struct RecipeCollectionId : IKeyObject<RecipeCollectionId, int>
{
    public static string ErrorCode => ErrorCodes.InvalidRecipeCollectionId;
    public static string ErrorMessage => "Recipe Collection Id must be positive.";

    public int Value { get; }

    private RecipeCollectionId(int value) => Value = value;

    public static RecipeCollectionId Create(int value)
    {
        return value >= Constraints.MinId
            ? new RecipeCollectionId(value)
            : ValueObjectException.Throw<RecipeCollectionId>(value);
    }

    public static bool TryCreate(int value, out RecipeCollectionId result)
    {
        var canCreate = value >= Constraints.MinId;

        result = canCreate ? new RecipeCollectionId(value) : default;

        return canCreate;
    }

    public static RecipeCollectionId CreateUnchecked(int value) => new(value);

    public override string ToString() => Value.ToString();

    public static RecipeCollectionId Parse(string s, IFormatProvider? provider)
    {
        return Create(int.Parse(s, provider));
    }

    public static bool TryParse([NotNullWhen(true)] string? s, IFormatProvider? provider, out RecipeCollectionId result)
    {
        result = default;

        return int.TryParse(s, provider, out var value) && TryCreate(value, out result);
    }

    public static implicit operator int(RecipeCollectionId valueObject) => valueObject.Value;
}