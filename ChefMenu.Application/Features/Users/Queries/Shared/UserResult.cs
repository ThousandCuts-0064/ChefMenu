using System.Linq.Expressions;
using ChefMenu.Application.Core.Results;
using ChefMenu.Domain.Enums;
using ChefMenu.Domain.Features.Shared.ValueObjects;
using ChefMenu.Domain.Features.Users;
using ChefMenu.Domain.Features.Users.ValueObjects;

namespace ChefMenu.Application.Features.Users.Queries.Shared;

public sealed class UserResult : IResult
{
    public required UserId Id { get; init; }
    public required Username Username { get; init; }
    public required UserRole Role { get; set; }
    public required DisplayName DisplayName { get; set; }
    public Description? Description { get; set; }
    public Uri? ImageUri { get; set; }
    public Rank? Rank { get; set; }

    public static Expression<Func<User, UserResult>> FromEntity { get; } = x => new UserResult
    {
        Id = x.Id,
        Username = x.Username,
        Role = x.Role,
        DisplayName = x.DisplayName,
        Description = x.Description,
        ImageUri = x.ImageUri,
        Rank = x.Rank,
    };
}