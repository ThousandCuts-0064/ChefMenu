using System.Diagnostics.CodeAnalysis;
using System.Text.RegularExpressions;
using ChefMenu.Domain.Errors;
using ChefMenu.Domain.Exceptions;
using ChefMenu.Domain.Features.Core.ValueObjects;

namespace ChefMenu.Domain.Features.Ingredients.ValueObjects;

public readonly partial record struct IngredientName : IKeyObject<IngredientName, string>
{
    [StringSyntax(StringSyntaxAttribute.Regex)]
    public const string Pattern = "^[a-zA-Z ]{2,16}$";

    [GeneratedRegex(Pattern)]
    public static partial Regex Regex { get; }

    public static string ErrorCode => ErrorCodes.InvalidIngredientName;
    public static string ErrorMessage => "Ingredient Name must contain 2-16 letter or space characters.";

    public string Value { get; }

    private IngredientName(string value) => Value = value;

    public static IngredientName Create(string value)
    {
        return Regex.IsMatch(value)
            ? new IngredientName(value)
            : ValueObjectException.Throw<IngredientName>(value);
    }

    public static bool TryCreate(string value, out IngredientName result)
    {
        var canCreate = Regex.IsMatch(value);

        result = canCreate ? new IngredientName(value) : default;

        return canCreate;
    }

    public static IngredientName CreateUnchecked(string value) => new(value);

    public override string ToString() => Value;

    public static implicit operator string(IngredientName valueObject) => valueObject.Value;
}