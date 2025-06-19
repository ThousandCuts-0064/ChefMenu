namespace ChefMenu.Domain.Features.Core.ValueObjects;

public interface IKeyObject : IValueObject;

public interface IKeyObject<out TValue> : IKeyObject, IValueObject<TValue>
    where TValue : notnull;

public interface IKeyObject<TSelf, TValue> : IKeyObject<TValue>, IValueObject<TSelf, TValue>
    where TSelf : struct, IValueObject<TSelf, TValue>
    where TValue : notnull;