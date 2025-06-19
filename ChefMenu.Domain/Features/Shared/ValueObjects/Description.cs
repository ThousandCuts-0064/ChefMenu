using ChefMenu.Domain.Features.Core.ValueObjects;

namespace ChefMenu.Domain.Features.Shared.ValueObjects;

public readonly record struct Description : IValueObject<Description, string>
{
    public static string ErrorCode => throw new NotSupportedException();
    public static string ErrorMessage => throw new NotSupportedException();

    public string Value { get; }

    private Description(string value) => Value = value;

    public static Description Create(string value) => new(value);

    public static bool TryCreate(string value, out Description result)
    {
        result = new Description(value);

        return true;
    }

    public static Description CreateUnchecked(string value) => new(value);

    public override string ToString() => Value;

    public static implicit operator string(Description valueObject) => valueObject.Value;
}