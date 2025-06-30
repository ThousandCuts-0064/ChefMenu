using System.Diagnostics.CodeAnalysis;
using System.Text.RegularExpressions;
using ChefMenu.Domain.Errors;
using ChefMenu.Domain.Exceptions;
using ChefMenu.Domain.Features.Core.ValueObjects;

namespace ChefMenu.Domain.Features.Recipes.ValueObjects;

public readonly partial record struct RecipeName : IKeyObject<RecipeName, string>
{
    [StringSyntax(StringSyntaxAttribute.Regex)]
    public const string Pattern = "^[a-zA-Z ]{2,63}$";

    [GeneratedRegex(Pattern)]
    public static partial Regex Regex { get; }

    public static string ErrorCode => ErrorCodes.InvalidRecipeName;
    public static string ErrorMessage => "Recipe Name must contain 2-63 letter or space characters.";

    public string Value { get; }

    private RecipeName(string value) => Value = value;

    public static RecipeName Create(string value)
    {
        return Regex.IsMatch(value)
            ? new RecipeName(value)
            : ValueObjectException.Throw<RecipeName>(value);
    }

    public static bool TryCreate(string value, out RecipeName result)
    {
        var canCreate = Regex.IsMatch(value);

        result = canCreate ? new RecipeName(value) : default;

        return canCreate;
    }

    public static RecipeName CreateUnchecked(string value) => new(value);

    public override string ToString() => Value;

    public static RecipeName Parse(string s, IFormatProvider? provider)
    {
        return Create(s);
    }

    public static bool TryParse([NotNullWhen(true)] string? s, IFormatProvider? provider, out RecipeName result)
    {
        result = default;

        return s is not null && TryCreate(s, out result);
    }

    public static implicit operator string(RecipeName valueObject) => valueObject.Value;
}