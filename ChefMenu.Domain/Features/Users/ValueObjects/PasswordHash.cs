using ChefMenu.Domain.Features.Core.ValueObjects;

namespace ChefMenu.Domain.Features.Users.ValueObjects;

public readonly record struct PasswordHash : IValueObject<PasswordHash, string>
{
    public static string ErrorCode => throw new NotSupportedException();
    public static string ErrorMessage => throw new NotSupportedException();

    public string Value { get; }

    private PasswordHash(string value) => Value = value;

    public static PasswordHash Create(string value) => new(value);

    public static bool TryCreate(string value, out PasswordHash result)
    {
        result = new PasswordHash(value);

        return true;
    }

    public static PasswordHash CreateUnchecked(string value) => new(value);

    public override string ToString() => Value;

    public static implicit operator string(PasswordHash valueObject) => valueObject.Value;
}