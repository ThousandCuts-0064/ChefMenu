using ChefMenu.Domain.Features.Core.ValueObjects;

namespace ChefMenu.Domain.Features.Shared.ValueObjects;

public readonly record struct Text : IValueObject<Text, string>
{
    public static string ErrorCode => throw new NotSupportedException();
    public static string ErrorMessage => throw new NotSupportedException();

    public string Value { get; }

    private Text(string value) => Value = value;

    public static Text Create(string value) => new(value);

    public static bool TryCreate(string value, out Text result)
    {
        result = new Text(value);

        return true;
    }

    public static Text CreateUnchecked(string value) => new(value);

    public override string ToString() => Value;

    public static implicit operator string(Text valueObject) => valueObject.Value;
}