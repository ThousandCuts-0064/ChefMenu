using ChefMenu.Domain.Features.Core.ValueObjects;

namespace ChefMenu.Domain.Features.SystemActionHistories.ValueObjects;

public readonly record struct EntityName  : IValueObject<EntityName, string>
{
    public static string ErrorCode => throw new NotSupportedException();
    public static string ErrorMessage => throw new NotSupportedException();

    public string Value { get; }

    private EntityName(string value) => Value = value;

    public static EntityName Create(string value) => new(value);

    public static bool TryCreate(string value, out EntityName result)
    {
        result = new EntityName(value);

        return true;
    }

    public static EntityName CreateUnchecked(string value) => new(value);

    public override string ToString() => Value;

    public static implicit operator string(EntityName valueObject) => valueObject.Value;
}