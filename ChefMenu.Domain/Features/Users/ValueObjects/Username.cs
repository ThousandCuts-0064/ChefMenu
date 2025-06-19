using System.Diagnostics.CodeAnalysis;
using System.Text.RegularExpressions;
using ChefMenu.Domain.Errors;
using ChefMenu.Domain.Exceptions;
using ChefMenu.Domain.Features.Core.ValueObjects;

namespace ChefMenu.Domain.Features.Users.ValueObjects;

public readonly partial record struct Username : IKeyObject<Username, string>
{
    [StringSyntax(StringSyntaxAttribute.Regex)]
    public const string Pattern = "^[a-zA-Z0-9_.+-]{2,16}$";

    [GeneratedRegex(Pattern)]
    public static partial Regex Regex { get; }

    public static string ErrorCode => ErrorCodes.InvalidUsername;
    public static string ErrorMessage => "Username must contain 2-16 alphanumeric or [_ . + -] characters.";

    public string Value { get; }

    private Username(string value) => Value = value;

    public static Username Create(string value)
    {
        return Regex.IsMatch(value)
            ? new Username(value)
            : ValueObjectException.Throw<Username>(value);
    }

    public static bool TryCreate(string value, out Username result)
    {
        var canCreate = Regex.IsMatch(value);

        result = canCreate ? new Username(value) : default;

        return canCreate;
    }

    public static Username CreateUnchecked(string value) => new(value);

    public override string ToString() => Value;

    public static implicit operator string(Username valueObject) => valueObject.Value;
}