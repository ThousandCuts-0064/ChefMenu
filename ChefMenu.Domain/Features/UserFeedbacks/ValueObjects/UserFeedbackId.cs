using System.Diagnostics.CodeAnalysis;
using ChefMenu.Domain.Constants;
using ChefMenu.Domain.Errors;
using ChefMenu.Domain.Exceptions;
using ChefMenu.Domain.Features.Core.ValueObjects;

namespace ChefMenu.Domain.Features.UserFeedbacks.ValueObjects;

public readonly record struct UserFeedbackId : IKeyObject<UserFeedbackId, int>
{
    public static string ErrorCode => ErrorCodes.InvalidUserFeedbackId;
    public static string ErrorMessage => "User Feedback Id must be positive.";

    public int Value { get; }

    private UserFeedbackId(int value) => Value = value;

    public static UserFeedbackId Create(int value)
    {
        return value >= Constraints.MinId
            ? new UserFeedbackId(value)
            : ValueObjectException.Throw<UserFeedbackId>(value);
    }

    public static bool TryCreate(int value, out UserFeedbackId result)
    {
        var canCreate = value >= Constraints.MinId;

        result = canCreate ? new UserFeedbackId(value) : default;

        return canCreate;
    }

    public static UserFeedbackId CreateUnchecked(int value) => new(value);

    public override string ToString() => Value.ToString();

    public static UserFeedbackId Parse(string s, IFormatProvider? provider)
    {
        return Create(int.Parse(s, provider));
    }

    public static bool TryParse([NotNullWhen(true)] string? s, IFormatProvider? provider, out UserFeedbackId result)
    {
        result = default;

        return int.TryParse(s, provider, out var value) && TryCreate(value, out result);
    }

    public static implicit operator int(UserFeedbackId valueObject) => valueObject.Value;
}