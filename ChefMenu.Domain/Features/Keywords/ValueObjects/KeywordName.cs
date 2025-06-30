using System.Diagnostics.CodeAnalysis;
using System.Text.RegularExpressions;
using ChefMenu.Domain.Errors;
using ChefMenu.Domain.Exceptions;
using ChefMenu.Domain.Features.Core.ValueObjects;

namespace ChefMenu.Domain.Features.Keywords.ValueObjects;

public readonly partial record struct KeywordName : IKeyObject<KeywordName, string>
{
    [StringSyntax(StringSyntaxAttribute.Regex)]
    public const string Pattern = "^[a-zA-Z ]{2,16}$";

    [GeneratedRegex(Pattern)]
    public static partial Regex Regex { get; }

    public static string ErrorCode => ErrorCodes.InvalidKeywordName;
    public static string ErrorMessage => "Keyword Name must contain 2-16 letter or space characters.";

    public string Value { get; }

    private KeywordName(string value) => Value = value;

    public static KeywordName Create(string value)
    {
        return Regex.IsMatch(value)
            ? new KeywordName(value)
            : ValueObjectException.Throw<KeywordName>(value);
    }

    public static bool TryCreate(string value, out KeywordName result)
    {
        var canCreate = Regex.IsMatch(value);

        result = canCreate ? new KeywordName(value) : default;

        return canCreate;
    }

    public static KeywordName CreateUnchecked(string value) => new(value);

    public override string ToString() => Value;

    public static KeywordName Parse(string s, IFormatProvider? provider)
    {
        return Create(s);
    }

    public static bool TryParse([NotNullWhen(true)] string? s, IFormatProvider? provider, out KeywordName result)
    {
        result = default;

        return s is not null && TryCreate(s, out result);
    }

    public static implicit operator string(KeywordName valueObject) => valueObject.Value;
}