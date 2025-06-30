namespace ChefMenu.Domain.Features.Core.ValueObjects;

public interface IKeyObject : IValueObject;

public interface IKeyObject<out TValue> : IKeyObject, IValueObject<TValue>
    where TValue : notnull;

public interface IKeyObject<TSelf, TValue> : IKeyObject<TValue>, IValueObject<TSelf, TValue>, IParsable<TSelf>
    where TSelf : struct, IKeyObject<TSelf, TValue>
    where TValue : notnull;