using System.Diagnostics.CodeAnalysis;
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

public readonly record struct Required<T> : IParsable<Required<T>>
    where T : struct, IValueObject
{
    private readonly T _valueObject;

    public required T ValueObject
    {
        get => IsValid
            ? _valueObject
            : throw new InvalidOperationException($"{typeof(Required<T>).Name} was not validated.");
        init => _valueObject = value;
    }

    public bool IsValid { get; init; }

    public static implicit operator T(Required<T> required) => required.ValueObject;
    public static Required<T> Parse(string s, IFormatProvider? provider)
    {
        throw new NotImplementedException();
    }
    public static bool TryParse([NotNullWhen(true)] string? s, IFormatProvider? provider, out Required<T> result)
    {
        throw new NotImplementedException();
    }
}