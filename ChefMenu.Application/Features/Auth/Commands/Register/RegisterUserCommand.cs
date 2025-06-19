using ChefMenu.Application.Core.Commands;
using ChefMenu.Application.Core.Results;
using ChefMenu.Application.Features.Auth.Commands.Register.Results;
using ChefMenu.Domain.Enums;
using ChefMenu.Domain.Features.Shared.ValueObjects;
using ChefMenu.Domain.Features.Users;
using ChefMenu.Domain.Features.Users.ValueObjects;

namespace ChefMenu.Application.Features.Auth.Commands.Register;

public sealed class RegisterUserCommand : Command<RegisterUserCommand, Results<
    UserCreatedResult,
    UsernameAlreadyExistsResult>>
{
    public required Username Username { get; init; }
    public required Email Email { get; init; }
    public required Password Password { get; init; }
    public required DisplayName DisplayName { get; init; }

    internal User ToEntity(PasswordHash passwordHash) => new()
    {
        Username = Username,
        Email = Email,
        PasswordHash = passwordHash,
        Role = UserRole.Cook,
        DisplayName = DisplayName,
    };
}