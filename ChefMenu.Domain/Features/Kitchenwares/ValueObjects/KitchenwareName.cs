using System.Diagnostics.CodeAnalysis;
using System.Text.RegularExpressions;
using ChefMenu.Domain.Errors;
using ChefMenu.Domain.Exceptions;
using ChefMenu.Domain.Features.Core.ValueObjects;

namespace ChefMenu.Domain.Features.Kitchenwares.ValueObjects;

public readonly partial record struct KitchenwareName: IKeyObject<KitchenwareName, string>
{
    [StringSyntax(StringSyntaxAttribute.Regex)]
    public const string Pattern = "^[a-zA-Z ]{2,16}$";

    [GeneratedRegex(Pattern)]
    public static partial Regex Regex { get; }

    public static string ErrorCode => ErrorCodes.InvalidKitchenwareName;
    public static string ErrorMessage => "Kitchenware Name must contain 2-16 letter or space characters.";

    public string Value { get; }

    private KitchenwareName(string value) => Value = value;

    public static KitchenwareName Create(string value)
    {
        return Regex.IsMatch(value)
            ? new KitchenwareName(value)
            : ValueObjectException.Throw<KitchenwareName>(value);
    }

    public static bool TryCreate(string value, out KitchenwareName result)
    {
        var canCreate = Regex.IsMatch(value);

        result = canCreate ? new KitchenwareName(value) : default;

        return canCreate;
    }

    public static KitchenwareName CreateUnchecked(string value) => new(value);

    public override string ToString() => Value;

    public static implicit operator string(KitchenwareName valueObject) => valueObject.Value;
}