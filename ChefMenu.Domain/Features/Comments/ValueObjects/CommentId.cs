using ChefMenu.Domain.Constants;
using ChefMenu.Domain.Errors;
using ChefMenu.Domain.Exceptions;
using ChefMenu.Domain.Features.Core.ValueObjects;

namespace ChefMenu.Domain.Features.Comments.ValueObjects;

public readonly record struct CommentId : IKeyObject<CommentId, int>
{
    public static string ErrorCode => ErrorCodes.InvalidCommentId;
    public static string ErrorMessage => "Comment Id must be positive.";

    public int Value { get; }

    private CommentId(int value) => Value = value;

    public static CommentId Create(int value)
    {
        return value >= Constraints.MinId
            ? new CommentId(value)
            : ValueObjectException.Throw<CommentId>(value);
    }

    public static bool TryCreate(int value, out CommentId result)
    {
        var canCreate = value >= Constraints.MinId;

        result = canCreate ? new CommentId(value) : default;

        return canCreate;
    }

    public static CommentId CreateUnchecked(int value) => new(value);

    public override string ToString() => Value.ToString();

    public static implicit operator int(CommentId valueObject) => valueObject.Value;
}