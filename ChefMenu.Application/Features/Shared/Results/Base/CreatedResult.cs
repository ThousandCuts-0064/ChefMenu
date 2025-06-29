using ChefMenu.Application.Core.Results;
using ChefMenu.Domain.Features.Core.ValueObjects;

namespace ChefMenu.Application.Features.Shared.Results.Base;

public abstract class CreatedResult<TKey> : IResult
    where TKey : struct, IKeyObject

{
    public TKey Id { get; init; }
}
