using System.Text.Json;
using ChefMenu.Domain.Features.Core;
using ChefMenu.Domain.Features.SystemConfigs.ValueObjects;
using ChefMenu.Domain.Features.Users;
using ChefMenu.Domain.Features.Users.ValueObjects;

namespace ChefMenu.Domain.Features.SystemConfigs;

public sealed class SystemConfig : IAuditableEntity
{
    public SystemConfigKey Key { get; init; }

    public UserId CreatedById { get; init; }
    public UserId? UpdatedById { get; set; }
    public UserId? DeletedById { get; set; }

    public JsonElement Content { get; set; }

    public DateTime CreatedAt { get; init; }
    public DateTime? UpdatedAt { get; set; }
    public DateTime? DeletedAt { get; set; }

    public User CreatedBy { get; init; } = null!;
    public User? UpdatedBy { get; set; }
    public User? DeletedBy { get; set; }
}