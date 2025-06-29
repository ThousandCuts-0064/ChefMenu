using ChefMenu.Application.Results;
using ChefMenu.Domain.Features.Core.ValueObjects;

namespace ChefMenu.Application.Features.Shared.Results.Base;

public abstract class NameAlreadyExists<TName> : IErrorResult
    where TName : struct, IKeyObject
{
    public abstract string ErrorCode { get; }
    public abstract string ErrorMessage { get; }

    public required TName Name { get; init; }
}
