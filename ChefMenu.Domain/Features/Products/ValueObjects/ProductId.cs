using ChefMenu.Domain.Constants;
using ChefMenu.Domain.Errors;
using ChefMenu.Domain.Exceptions;
using ChefMenu.Domain.Features.Core.ValueObjects;

namespace ChefMenu.Domain.Features.Products.ValueObjects;

public readonly record struct ProductId : IKeyObject<ProductId, int>
{
    public static string ErrorCode => ErrorCodes.InvalidProductId;
    public static string ErrorMessage => "Product Id must be positive.";

    public int Value { get; }

    private ProductId(int value) => Value = value;

    public static ProductId Create(int value)
    {
        return value >= Constraints.MinId
            ? new ProductId(value)
            : ValueObjectException.Throw<ProductId>(value);
    }

    public static bool TryCreate(int value, out ProductId result)
    {
        var canCreate = value >= Constraints.MinId;

        result = canCreate ? new ProductId(value) : default;

        return canCreate;
    }

    public static ProductId CreateUnchecked(int value) => new(value);

    public override string ToString() => Value.ToString();

    public static implicit operator int(ProductId valueObject) => valueObject.Value;
}