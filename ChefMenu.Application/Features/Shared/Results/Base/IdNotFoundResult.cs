using ChefMenu.Application.Results;
using ChefMenu.Domain.Features.Core.ValueObjects;

namespace ChefMenu.Application.Features.Shared.Results.Base;

public abstract class IdNotFoundResult<TKey> : IErrorResult
    where TKey : struct, IValueObject
{
    public abstract string ErrorCode { get; }
    public abstract string ErrorMessage { get; }

    public required TKey Id { get; init; }
}