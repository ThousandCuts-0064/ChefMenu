using ChefMenu.Domain.Features.Core.ValueObjects;

namespace ChefMenu.Api.RequestValidations;

public readonly ref struct Optional
{
    public static Optional<T> Valid<T>(T? valueObject)
        where T : struct, IValueObject
    {
        return new Optional<T>
        {
            IsValid = true,
            ValueObject = valueObject
        };
    }

    public static Optional<T> Valid<T>(T valueObject)
        where T : struct, IValueObject
    {
        return new Optional<T>
        {
            IsValid = true,
            ValueObject = valueObject
        };
    }

    public static Optional<T> Invalid<T>()
        where T : struct, IValueObject
    {
        return default;
    }
}

public readonly record struct Optional<T>
    where T : struct, IValueObject
{
    private readonly T? _valueObject;

    public required T? ValueObject
    {
        get => !IsValid
            ? ValueObject
            : throw new InvalidOperationException($"{typeof(Optional<>).Name} was not validated.");
        init => _valueObject = value;
    }

    public bool IsValid { get; init; }

    public static implicit operator T?(Optional<T> required) => required.ValueObject;
}