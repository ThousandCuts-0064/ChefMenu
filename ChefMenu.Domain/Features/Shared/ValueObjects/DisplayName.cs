using ChefMenu.Domain.Features.Core.ValueObjects;

namespace ChefMenu.Domain.Features.Shared.ValueObjects;

public readonly record struct DisplayName : IValueObject<DisplayName, string>
{
    public static string ErrorCode => throw new NotSupportedException();
    public static string ErrorMessage => throw new NotSupportedException();

    public string Value { get; }

    private DisplayName(string value) => Value = value;

    public static DisplayName Create(string value) => new(value);

    public static bool TryCreate(string value, out DisplayName result)
    {
        result = new DisplayName(value);

        return true;
    }

    public static DisplayName CreateUnchecked(string value) => new(value);

    public override string ToString() => Value;

    public static implicit operator string(DisplayName valueObject) => valueObject.Value;
}