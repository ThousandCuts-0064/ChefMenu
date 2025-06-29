using System.Linq.Expressions;
using ChefMenu.Application.Core.Results;
using ChefMenu.Domain.Enums;
using ChefMenu.Domain.Features.Shared.ValueObjects;
using ChefMenu.Domain.Features.Users;
using ChefMenu.Domain.Features.Users.ValueObjects;

namespace ChefMenu.Application.Features.Me.Queries.Get.Results;

public sealed class MeResult : IResult
{
    public required UserId Id { get; init; }
    public required Username Username { get; init; }
    public required Email Email { get; set; }
    public required UserRole Role { get; set; }
    public required DisplayName DisplayName { get; set; }
    public required Description? Description { get; set; }
    public required DateTime CreatedAt { get; init; }
    public required DateTime? UpdatedAt { get; set; }
    public required Uri? ImageUri { get; set; }
    public required Rank? Rank { get; set; }
    public required bool IsPublic { get; set; }

    public static Expression<Func<User, MeResult>> FromEntity { get; } = x => new MeResult
    {
        Id = x.Id,
        Username = x.Username,
        Email = x.Email,
        Role = x.Role,
        DisplayName = x.DisplayName,
        Description = x.Description,
        CreatedAt = x.CreatedAt,
        UpdatedAt = x.UpdatedAt,
        ImageUri = x.ImageUri,
        Rank = x.Rank,
        IsPublic = x.IsPublic
    };

}
