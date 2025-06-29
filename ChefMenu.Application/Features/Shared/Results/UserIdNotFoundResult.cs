using ChefMenu.Application.Errors;
using ChefMenu.Application.Results;
using ChefMenu.Domain.Features.Users.ValueObjects;

namespace ChefMenu.Application.Features.Shared.Results;

public sealed class UserIdNotFoundResult : IErrorResult
{
    public string ErrorCode => AppErrorCodes.UserIdNotFound;
    public string ErrorMessage => $"User Id {Id} not found.";

    public required UserId Id { get; init; }
}
