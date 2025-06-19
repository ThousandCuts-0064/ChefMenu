using ChefMenu.Domain.Constants;
using ChefMenu.Domain.Errors;
using ChefMenu.Domain.Exceptions;
using ChefMenu.Domain.Features.Core.ValueObjects;

namespace ChefMenu.Domain.Features.Categories.ValueObjects;

public readonly record struct CategoryId : IKeyObject<CategoryId, int>
{
    public static string ErrorCode => ErrorCodes.InvalidCategoryId;
    public static string ErrorMessage => "Category Id must be positive.";

    public int Value { get; }

    private CategoryId(int value) => Value = value;

    public static CategoryId Create(int value)
    {
        return value >= Constraints.MinId
            ? new CategoryId(value)
            : ValueObjectException.Throw<CategoryId>(value);
    }

    public static bool TryCreate(int value, out CategoryId result)
    {
        var canCreate = value >= Constraints.MinId;

        result = canCreate ? new CategoryId(value) : default;

        return canCreate;
    }

    public static CategoryId CreateUnchecked(int value) => new(value);

    public override string ToString() => Value.ToString();

    public static implicit operator int(CategoryId valueObject) => valueObject.Value;
}