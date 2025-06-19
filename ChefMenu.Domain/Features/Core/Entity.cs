using ChefMenu.Domain.Features.Core.ValueObjects;

namespace ChefMenu.Domain.Features.Core;

public abstract class Entity<TKey>
    where TKey : struct, IKeyObject
{
    public TKey Id { get; init; }
}
