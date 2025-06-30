using System.Diagnostics.CodeAnalysis;
using ChefMenu.Domain.Features.Core.ValueObjects;

namespace ChefMenu.Domain.Features.SystemConfigs.ValueObjects;

public readonly record struct SystemConfigKey : IKeyObject<SystemConfigKey, string>
{
    public static string ErrorCode => throw new NotSupportedException();
    public static string ErrorMessage => throw new NotSupportedException();

    public string Value { get; }

    private SystemConfigKey(string value) => Value = value;

    public static SystemConfigKey Create(string value) => new(value);

    public static bool TryCreate(string value, out SystemConfigKey result)
    {
        result = new SystemConfigKey(value);

        return true;
    }

    public static SystemConfigKey CreateUnchecked(string value) => new(value);

    public override string ToString() => Value;

    public static SystemConfigKey Parse(string s, IFormatProvider? provider)
    {
        return Create(s);
    }

    public static bool TryParse([NotNullWhen(true)] string? s, IFormatProvider? provider, out SystemConfigKey result)
    {
        result = default;

        return s is not null && TryCreate(s, out result);
    }

    public static implicit operator string(SystemConfigKey valueObject) => valueObject.Value;
}