namespace ChefMenu.Domain.Features.Core.ValueObjects;

public interface IValueObject
{
    public static abstract string ErrorCode { get; }
    public static abstract string ErrorMessage { get; }
}

public interface IValueObject<out TValue> : IValueObject
    where TValue : notnull
{
    public TValue Value { get; }
}

public interface IValueObject<TSelf, TValue> : IValueObject<TValue>
    where TSelf : struct, IValueObject<TSelf, TValue>
    where TValue : notnull
{
    public static abstract TSelf Create(TValue value);
    public static abstract bool TryCreate(TValue value, out TSelf result);
    public static abstract TSelf CreateUnchecked(TValue value);

    public static abstract implicit operator TValue(TSelf valueObject);
}