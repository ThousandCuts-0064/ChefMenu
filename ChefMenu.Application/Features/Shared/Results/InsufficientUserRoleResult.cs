using ChefMenu.Application.Errors;
using ChefMenu.Application.Results;
using ChefMenu.Domain.Enums;

namespace ChefMenu.Application.Features.Shared.Results;

public sealed class InsufficientUserRoleResult : IErrorResult
{
    public string ErrorCode  => AppErrorCodes.InsufficientUserRole;
    public string ErrorMessage => $"User Role {Role} is insufficient.";

    public required UserRole Role { get; init; }
}
