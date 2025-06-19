using ChefMenu.Domain.Features.Core.ValueObjects;

namespace ChefMenu.Domain.Features.Shared.ValueObjects;

public readonly record struct Rank : IValueObject<Rank, int>
{
    public static string ErrorCode => throw new NotSupportedException();
    public static string ErrorMessage => throw new NotSupportedException();

    public int Value { get; }

    private Rank(int value) => Value = value;

    public static Rank Create(int value) => new(value);

    public static bool TryCreate(int value, out Rank result)
    {
        result = new Rank(value);

        return true;
    }

    public static Rank CreateUnchecked(int value) => new(value);

    public override string ToString() => Value.ToString();

    public static implicit operator int(Rank valueObject) => valueObject.Value;
}