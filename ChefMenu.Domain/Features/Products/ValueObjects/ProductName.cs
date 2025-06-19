using System.Diagnostics.CodeAnalysis;
using System.Text.RegularExpressions;
using ChefMenu.Domain.Errors;
using ChefMenu.Domain.Exceptions;
using ChefMenu.Domain.Features.Core.ValueObjects;

namespace ChefMenu.Domain.Features.Products.ValueObjects;

public readonly partial record struct ProductName : IKeyObject<ProductName, string>
{
    [StringSyntax(StringSyntaxAttribute.Regex)]
    public const string Pattern = "^[a-zA-Z ]{2,16}$";

    [GeneratedRegex(Pattern)]
    public static partial Regex Regex { get; }

    public static string ErrorCode => ErrorCodes.InvalidProductName;
    public static string ErrorMessage => "Product Name must contain 2-16 letter or space characters.";

    public string Value { get; }

    private ProductName(string value) => Value = value;

    public static ProductName Create(string value)
    {
        return Regex.IsMatch(value)
            ? new ProductName(value)
            : ValueObjectException.Throw<ProductName>(value);
    }

    public static bool TryCreate(string value, out ProductName result)
    {
        var canCreate = Regex.IsMatch(value);

        result = canCreate ? new ProductName(value) : default;

        return canCreate;
    }

    public static ProductName CreateUnchecked(string value) => new(value);

    public override string ToString() => Value;

    public static implicit operator string(ProductName valueObject) => valueObject.Value;
}