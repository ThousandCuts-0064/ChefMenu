using System.Diagnostics.CodeAnalysis;
using System.Text.RegularExpressions;
using ChefMenu.Domain.Errors;
using ChefMenu.Domain.Exceptions;
using ChefMenu.Domain.Features.Core.ValueObjects;

namespace ChefMenu.Domain.Features.Categories.ValueObjects;

public readonly partial record struct CategoryName : IKeyObject<CategoryName, string>
{
    [StringSyntax(StringSyntaxAttribute.Regex)]
    public const string Pattern = "^[a-zA-Z ]{2,16}$";

    [GeneratedRegex(Pattern)]
    public static partial Regex Regex { get; }

    public static string ErrorCode => ErrorCodes.InvalidCategoryName;
    public static string ErrorMessage => "Category Name must contain 2-16 letter or space characters.";

    public string Value { get; }

    private CategoryName(string value) => Value = value;

    public static CategoryName Create(string value)
    {
        return Regex.IsMatch(value)
            ? new CategoryName(value)
            : ValueObjectException.Throw<CategoryName>(value);
    }

    public static bool TryCreate(string value, out CategoryName result)
    {
        var canCreate = Regex.IsMatch(value);

        result = canCreate ? new CategoryName(value) : default;

        return canCreate;
    }

    public static CategoryName CreateUnchecked(string value) => new(value);

    public override string ToString() => Value;

    public static implicit operator string(CategoryName valueObject) => valueObject.Value;
}