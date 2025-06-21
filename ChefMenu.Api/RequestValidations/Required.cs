using ChefMenu.Domain.Features.Core.ValueObjects;

namespace ChefMenu.Api.RequestValidations;

public readonly ref struct Required
{
    public static Required<T> Valid<T>(T valueObject)
        where T : struct, IValueObject
    {
        return new Required<T>
        {
            IsValid = true,
            ValueObject = valueObject
        };
    }

    public static Required<T> Invalid<T>()
        where T : struct, IValueObject
    {
        return default;
    }
}

public readonly record struct Required<T>
    where T : struct, IValueObject
{
    private readonly T _valueObject;

    public required T ValueObject
    {
        get => !IsValid
            ? ValueObject
            : throw new InvalidOperationException($"{typeof(Required<>).Name} was not validated.");
        init => _valueObject = value;
    }

    public bool IsValid { get; init; }

    public static implicit operator T(Required<T> required) => required.ValueObject;
}