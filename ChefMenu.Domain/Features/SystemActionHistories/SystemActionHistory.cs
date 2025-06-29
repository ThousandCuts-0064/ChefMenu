using System.Text.Json;
using ChefMenu.Domain.Enums;
using ChefMenu.Domain.Features.SystemActionHistories.ValueObjects;
using ChefMenu.Domain.Features.Users;
using ChefMenu.Domain.Features.Users.ValueObjects;

namespace ChefMenu.Domain.Features.SystemActionHistories;

public class SystemActionHistory
{
    public SystemActionHistoryId Id { get; init; }
    public UserId ExecutedById { get; init; }

    public required SystemActionType Type { get; init; }
    public required EntityName EntityName { get; init; }
    public required DateTime OccurredAt { get; init; }
    public required JsonElement Old { get; init; }
    public required JsonElement New { get; init; }

    public User ExecutedBy { get; init; } = null!;
}