﻿using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using ChefMenu.Domain.Features.Core.ValueObjects;

namespace ChefMenu.Domain.Exceptions;

public class ValueObjectException : DomainException
{
    public Type Type { get; }
    public object? Value { get; }

    protected ValueObjectException(
        string code,
        string message,
        Type type,
        object? value)
        : base(code, message)
    {
        Type = type;
        Value = value;
    }

    [DebuggerStepThrough]
    [DoesNotReturn]
    public static TValueObject Throw<TValueObject>(object? value)
        where TValueObject : IValueObject
    {
        throw new ValueObjectException(
            TValueObject.ErrorCode,
            TValueObject.ErrorMessage,
            typeof(TValueObject),
            typeof(TValueObject).IsAssignableTo(typeof(ISecretObject)) ? nameof(ISecretObject) : value);
    }
}