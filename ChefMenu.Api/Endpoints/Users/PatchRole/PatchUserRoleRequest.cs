using ChefMenu.Api.RequestValidations;
using ChefMenu.Domain.Enums;

namespace ChefMenu.Api.Endpoints.Users.PatchRole;

public sealed class PatchUserRoleRequest : IValidatableRequest
{
    public required UserRole Role { get; init; }

    public void Validate(RequestValidationContext context)
    {
    }
}