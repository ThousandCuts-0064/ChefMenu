using ChefMenu.Domain.Constants;
using ChefMenu.Domain.Errors;
using ChefMenu.Domain.Exceptions;
using ChefMenu.Domain.Features.Core.ValueObjects;

namespace ChefMenu.Domain.Features.SystemActionHistories.ValueObjects;

public readonly record struct SystemActionHistoryId : IKeyObject<SystemActionHistoryId, int>
{
    public static string ErrorCode => ErrorCodes.InvalidSystemActionHistoryId;
    public static string ErrorMessage => "System Action History Id must be positive.";

    public int Value { get; }

    private SystemActionHistoryId(int value) => Value = value;

    public static SystemActionHistoryId Create(int value)
    {
        return value >= Constraints.MinId
            ? new SystemActionHistoryId(value)
            : ValueObjectException.Throw<SystemActionHistoryId>(value);
    }

    public static bool TryCreate(int value, out SystemActionHistoryId result)
    {
        var canCreate = value >= Constraints.MinId;

        result = canCreate ? new SystemActionHistoryId(value) : default;

        return canCreate;
    }

    public static SystemActionHistoryId CreateUnchecked(int value) => new(value);

    public override string ToString() => Value.ToString();

    public static implicit operator int(SystemActionHistoryId valueObject) => valueObject.Value;
}