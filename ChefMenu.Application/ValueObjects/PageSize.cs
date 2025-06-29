using System.Diagnostics.CodeAnalysis;
using ChefMenu.Application.Errors;
using ChefMenu.Domain.Exceptions;
using ChefMenu.Domain.Features.Core.ValueObjects;

namespace ChefMenu.Application.ValueObjects;

public readonly record struct PageSize : IValueObject<PageSize, int>, IParsable<PageSize>
{
    public const int Min = 1;
    public const int Max = 100;

    public static PageSize Default { get; } = new(20);

    public static string ErrorCode => AppErrorCodes.IncorrectPageSize;
    public static string ErrorMessage => "Page Size must be between 1-100.";

    public int Value { get; }

    private PageSize(int value) => Value = value;

    public static PageSize Create(int value)
    {
        return value is >= Min and <= Max
            ? new PageSize(value)
            : ValueObjectException.Throw<PageSize>(value);
    }

    public static bool TryCreate(int value, out PageSize result)
    {
        var canCreate = value is >= Min and <= Max;

        result = canCreate ? new PageSize(value) : default;

        return canCreate;
    }

    public static PageSize CreateUnchecked(int value) => new(value);

    public override string ToString() => Value.ToString();

    public static PageSize Parse(string s, IFormatProvider? provider) => Create(int.Parse(s, provider));

    public static bool TryParse([NotNullWhen(true)] string? s, IFormatProvider? provider, out PageSize result)
    {
        result = default;

        return int.TryParse(s, provider, out var value) && TryCreate(value, out result);
    }

    public static implicit operator int(PageSize valueObject) => valueObject.Value;
}