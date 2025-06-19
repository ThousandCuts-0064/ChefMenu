using ChefMenu.Application.Core.Results;
using ChefMenu.Domain.Enums;
using ChefMenu.Domain.Features.Users.ValueObjects;

namespace ChefMenu.Application.Features.Auth.Commands.Register.Results;

public sealed class UserCreatedResult : IResult
{
    public required UserId Id { get; init; }
    public required Username Username { get; init; }
    public required UserRole Role { get; init; }
}