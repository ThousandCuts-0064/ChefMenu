using ChefMenu.Application.Errors;
using ChefMenu.Application.Results;

namespace ChefMenu.Application.Features.Auth.Queries.Login.Results;

public sealed class IncorrectUserCredentialsResult : IErrorResult
{
    public string ErrorCode => AppErrorCodes.IncorrectCredentials;
    public string ErrorMessage => "User credentials are incorrect.";
}
