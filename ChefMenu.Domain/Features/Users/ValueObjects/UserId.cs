using System.Diagnostics.CodeAnalysis;
using ChefMenu.Domain.Constants;
using ChefMenu.Domain.Errors;
using ChefMenu.Domain.Exceptions;
using ChefMenu.Domain.Features.Core.ValueObjects;

namespace ChefMenu.Domain.Features.Users.ValueObjects;

public readonly record struct UserId : IKeyObject<UserId, int>, IParsable<UserId>
{
    public static string ErrorCode => ErrorCodes.InvalidUserId;
    public static string ErrorMessage => "User Id must be positive.";

    public static UserId LastSystem { get; } = new(100);
    public static UserId InternalSystem { get; } = new(1);
    public static UserId PublicSystem { get; } = new(2);
    public static UserId AiSystem { get; } = new(3);

    public int Value { get; }

    private UserId(int value) => Value = value;

    public static UserId Create(int value)
    {
        return value >= Constraints.MinId
            ? new UserId(value)
            : ValueObjectException.Throw<UserId>(value);
    }

    public static bool TryCreate(int value, out UserId result)
    {
        var canCreate = value >= Constraints.MinId;

        result = canCreate ? new UserId(value) : default;

        return canCreate;
    }

    public static UserId CreateUnchecked(int value) => new(value);

    public override string ToString() => Value.ToString();

    public static UserId Parse(string s, IFormatProvider? provider = null)
    {
        return Create(int.Parse(s, provider));
    }

    public static bool TryParse([NotNullWhen(true)] string? s, IFormatProvider? provider, out UserId result)
    {
        result = default;

        return int.TryParse(s, provider, out var value) && TryCreate(value, out result);
    }

    public static implicit operator int(UserId valueObject) => valueObject.Value;
}