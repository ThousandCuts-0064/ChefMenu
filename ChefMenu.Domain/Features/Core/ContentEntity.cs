using ChefMenu.Domain.Features.Core.ValueObjects;

namespace ChefMenu.Domain.Features.Core;

public abstract class ContentEntity<TKey, TName> : NamedEntity<TKey, TName>
    where TKey : struct, IKeyObject
    where TName : struct, IValueObject
{
    public Uri? ImageUri { get; init; }
}