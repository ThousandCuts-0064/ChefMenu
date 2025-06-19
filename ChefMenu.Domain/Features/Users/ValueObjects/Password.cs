using ChefMenu.Domain.Errors;
using ChefMenu.Domain.Exceptions;
using ChefMenu.Domain.Features.Core.ValueObjects;

namespace ChefMenu.Domain.Features.Users.ValueObjects;

public readonly record struct Password : IValueObject<Password, string>, ISecretObject
{
    public const int MinLength = 8;

    public static string ErrorCode => ErrorCodes.InvalidPassword;
    public static string ErrorMessage => "Password must be at least 8 characters long.";

    public string Value { get; }

    private Password(string value) => Value = value;

    public static Password Create(string value)
    {
        return value.Length >= MinLength
            ? new Password(value)
            : ValueObjectException.Throw<Password>(value);
    }

    public static bool TryCreate(string value, out Password result)
    {
        var canCreate = value.Length >= MinLength;

        result = canCreate ? new Password(value) : default;

        return canCreate;
    }

    public static Password CreateUnchecked(string value) => new(value);

    public override string ToString() => $"'{nameof(Password)}'";

    public static implicit operator string(Password valueObject) => valueObject.Value;
}