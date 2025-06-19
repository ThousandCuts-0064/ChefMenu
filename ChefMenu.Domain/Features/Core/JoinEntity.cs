using ChefMenu.Domain.Features.Users;
using ChefMenu.Domain.Features.Users.ValueObjects;

namespace ChefMenu.Domain.Features.Core;

public abstract class JoinEntity
{
    public UserId CreatedById { get; init; }
    public DateTime CreatedAt { get; init; }

    public User CreatedBy { get; init; } = null!;
}