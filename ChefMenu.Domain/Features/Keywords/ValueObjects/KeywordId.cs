using ChefMenu.Domain.Constants;
using ChefMenu.Domain.Errors;
using ChefMenu.Domain.Exceptions;
using ChefMenu.Domain.Features.Core.ValueObjects;

namespace ChefMenu.Domain.Features.Keywords.ValueObjects;

public readonly record struct KeywordId : IKeyObject<KeywordId, int>
{
    public static string ErrorCode => ErrorCodes.InvalidKeywordId;
    public static string ErrorMessage => "Keyword Id must be positive.";

    public int Value { get; }

    private KeywordId(int value) => Value = value;

    public static KeywordId Create(int value)
    {
        return value >= Constraints.MinId
            ? new KeywordId(value)
            : ValueObjectException.Throw<KeywordId>(value);
    }

    public static bool TryCreate(int value, out KeywordId result)
    {
        var canCreate = value >= Constraints.MinId;

        result = canCreate ? new KeywordId(value) : default;

        return canCreate;
    }

    public static KeywordId CreateUnchecked(int value) => new(value);

    public override string ToString() => Value.ToString();

    public static implicit operator int(KeywordId valueObject) => valueObject.Value;
}