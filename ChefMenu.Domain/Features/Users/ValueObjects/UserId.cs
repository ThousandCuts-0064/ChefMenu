using ChefMenu.Domain.Constants;
using ChefMenu.Domain.Errors;
using ChefMenu.Domain.Exceptions;
using ChefMenu.Domain.Features.Core.ValueObjects;

namespace ChefMenu.Domain.Features.Users.ValueObjects;

public readonly record struct UserId : IKeyObject<UserId, int>
{
    public static string ErrorCode => ErrorCodes.InvalidUserId;
    public static string ErrorMessage => "User Id must be positive.";

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

    public static implicit operator int(UserId valueObject) => valueObject.Value;
}