using ChefMenu.Api.RequestValidations;
using ChefMenu.Domain.Features.Users.ValueObjects;

namespace ChefMenu.Api.Endpoints.Auth.Login;

public sealed class LoginUserRequest : IValidatableRequest
{
    public required Username? Username { get; init; }
    public required Password? Password { get; init; }

    public void Validate(RequestValidationContext context)
    {
        context.Require(Username);
        context.Require(Password);
    }
}