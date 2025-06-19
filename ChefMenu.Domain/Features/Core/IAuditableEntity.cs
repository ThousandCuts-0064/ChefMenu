using ChefMenu.Domain.Features.Users;
using ChefMenu.Domain.Features.Users.ValueObjects;

namespace ChefMenu.Domain.Features.Core;

public interface IAuditableEntity
{
    public UserId CreatedById { get; init; }
    public UserId? UpdatedById { get; set; }
    public UserId? DeletedById { get; set; }

    public DateTime CreatedAt { get; init; }
    public DateTime? UpdatedAt { get; set; }
    public DateTime? DeletedAt { get; set; }

    public User CreatedBy { get; init; }
    public User? UpdatedBy { get; set; }
    public User? DeletedBy { get; set; }
}