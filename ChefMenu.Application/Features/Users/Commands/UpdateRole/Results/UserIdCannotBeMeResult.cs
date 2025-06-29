using ChefMenu.Application.Errors;
using ChefMenu.Application.Results;

namespace ChefMenu.Application.Features.Users.Commands.UpdateRole.Results;

public sealed class UserIdCannotBeMeResult : IErrorResult
{
    public string ErrorCode => AppErrorCodes.UserIdCannotBeMe;
    public string ErrorMessage => "User Id cannot be me";

    public static UserIdCannotBeMeResult Instance { get; } = new();

    private UserIdCannotBeMeResult() { }
}