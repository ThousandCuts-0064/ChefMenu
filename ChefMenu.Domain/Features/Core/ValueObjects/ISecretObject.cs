using ChefMenu.Domain.Exceptions;

namespace ChefMenu.Domain.Features.Core.ValueObjects;

/// <summary>
/// Hides value in <see cref="ValueObjectException.Throw{TValueObject}(object)"/>
/// </summary>
public interface ISecretObject : IValueObject;