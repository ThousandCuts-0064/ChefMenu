using ChefMenu.Application.Core.Commands;
using ChefMenu.Application.Core.Results;
using ChefMenu.Application.Features.Shared.Results;
using ChefMenu.Application.Features.Users.Commands.UpdateRole.Results;
using ChefMenu.Domain.Enums;
using ChefMenu.Domain.Features.Users.ValueObjects;

namespace ChefMenu.Application.Features.Users.Commands.UpdateRole;

public sealed class UpdateUserRoleCommand : Command<UpdateUserRoleCommand, Results<
    SuccessResult,
    UserIdCannotBeMeResult,
    InsufficientUserRoleResult,
    UserIdNotFoundResult>>
{
    public required UserId MeId { get; init; }
    public required UserRole MeRole { get; init; }
    public required UserId UserId { get; init; }
    public required UserRole NewUserRole { get; init; }
}