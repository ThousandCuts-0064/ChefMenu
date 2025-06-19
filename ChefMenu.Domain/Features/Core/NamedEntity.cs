using ChefMenu.Domain.Features.Core.ValueObjects;
using ChefMenu.Domain.Features.Shared.ValueObjects;

namespace ChefMenu.Domain.Features.Core;

public abstract class NamedEntity<TKey, TName> : AuditableEntity<TKey>
    where TKey : struct, IKeyObject
    where TName : struct, IValueObject
{
    public required TName Name { get; set; }
    public required DisplayName DisplayName { get; set; }
    public Description? Description { get; set; }
}