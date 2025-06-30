using System.Diagnostics.CodeAnalysis;
using System.Text.RegularExpressions;
using ChefMenu.Domain.Errors;
using ChefMenu.Domain.Exceptions;
using ChefMenu.Domain.Features.Core.ValueObjects;

namespace ChefMenu.Domain.Features.RecipeCollections.ValueObjects;

public readonly partial record struct RecipeCollectionName : IKeyObject<RecipeCollectionName, string>
{
    [StringSyntax(StringSyntaxAttribute.Regex)]
    public const string Pattern = "^[a-zA-Z ]{2,63}$";

    [GeneratedRegex(Pattern)]
    public static partial Regex Regex { get; }

    public static string ErrorCode => ErrorCodes.InvalidRecipeCollectionName;
    public static string ErrorMessage => "Recipe Collection Name must contain 2-63 letter or space characters.";

    public string Value { get; }

    private RecipeCollectionName(string value) => Value = value;

    public static RecipeCollectionName Create(string value)
    {
        return Regex.IsMatch(value)
            ? new RecipeCollectionName(value)
            : ValueObjectException.Throw<RecipeCollectionName>(value);
    }

    public static bool TryCreate(string value, out RecipeCollectionName result)
    {
        var canCreate = Regex.IsMatch(value);

        result = canCreate ? new RecipeCollectionName(value) : default;

        return canCreate;
    }

    public static RecipeCollectionName CreateUnchecked(string value) => new(value);

    public override string ToString() => Value;

    public static RecipeCollectionName Parse(string s, IFormatProvider? provider)
    {
        return Create(s);
    }

    public static bool TryParse([NotNullWhen(true)] string? s, IFormatProvider? provider, out RecipeCollectionName result)
    {
        result = default;

        return s is not null && TryCreate(s, out result);
    }

    public static implicit operator string(RecipeCollectionName valueObject) => valueObject.Value;
}