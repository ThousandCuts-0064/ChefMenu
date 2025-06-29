using System.Diagnostics.CodeAnalysis;
using System.Text.RegularExpressions;
using ChefMenu.Domain.Errors;
using ChefMenu.Domain.Exceptions;
using ChefMenu.Domain.Features.Core.ValueObjects;

namespace ChefMenu.Domain.Features.Users.ValueObjects;

public readonly partial record struct Email : IKeyObject<Email, string>
{
    [StringSyntax(StringSyntaxAttribute.Regex)]
    public const string Pattern = @"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$";

    [GeneratedRegex(Pattern)]
    public static partial Regex Regex { get; }

    public static string ErrorCode => ErrorCodes.InvalidEmail;
    public static string ErrorMessage => "Email is invalid.";

    public static Email InternalSystem { get; } = new("chefmenu.internal@gmail.com");
    public static Email PublicSystem { get; } = new("chefmenu.public@gmail.com");
    public static Email AiSystem { get; } = new("chefmenu.ai@gmail.com");

    public string Value { get; }

    private Email(string value) => Value = value;

    public static Email Create(string value)
    {
        return Regex.IsMatch(value)
            ? new Email(value)
            : ValueObjectException.Throw<Email>(value);
    }

    public static bool TryCreate(string value, out Email result)
    {
        var canCreate = Regex.IsMatch(value);

        result = canCreate ? new Email(value) : default;

        return canCreate;
    }

    public static Email CreateUnchecked(string value) => new(value);

    public override string ToString() => Value;

    public static implicit operator string(Email valueObject) => valueObject.Value;
}