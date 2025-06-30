using ChefMenu.Application.Errors;
using ChefMenu.Application.Features.Shared.Results.Base;
using ChefMenu.Domain.Features.Users.ValueObjects;

namespace ChefMenu.Application.Features.Shared.Results;

public sealed class UserIdNotFoundResult : IdNotFoundResult<UserId>
{
    public override string ErrorCode => AppErrorCodes.UserIdNotFound;
    public override string ErrorMessage => $"User Id {Id} not found.";
}
