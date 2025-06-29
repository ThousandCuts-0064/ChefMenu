using ChefMenu.Application.Features.Shared.Results.Base;
using ChefMenu.Domain.Enums;
using ChefMenu.Domain.Features.Users.ValueObjects;

namespace ChefMenu.Application.Features.Auth.Commands.Register.Results;

public sealed class UserCreatedResult : CreatedResult<UserId>
{
    public required Username Username { get; init; }
    public required UserRole Role { get; init; }
}