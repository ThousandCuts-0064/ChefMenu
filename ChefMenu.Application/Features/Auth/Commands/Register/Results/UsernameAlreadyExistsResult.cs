using ChefMenu.Application.Errors;
using ChefMenu.Application.Results;
using ChefMenu.Domain.Features.Users.ValueObjects;

namespace ChefMenu.Application.Features.Auth.Commands.Register.Results;

public sealed class UsernameAlreadyExistsResult : IErrorResult
{
    public string ErrorCode => AppErrorCodes.UsernameDuplicate;
    public string ErrorMessage => $"Username {Username} already exists.";

    public required Username Username { get; init; }
}