using ChefMenu.Api.RequestValidations;
using ChefMenu.Domain.Features.Shared.ValueObjects;
using ChefMenu.Domain.Features.Users.ValueObjects;

namespace ChefMenu.Api.Endpoints.Auth.Register;

public sealed class RegisterUserRequest : IValidatableRequest
{
    public required Username? Username { get; init; }
    public required Email? Email { get; init; }
    public required Password? Password { get; init; }
    public required DisplayName? DisplayName { get; init; }

    public void Validate(RequestValidationContext context)
    {
        context.Require(Username);
        context.Require(Email);
        context.Require(Password);
        context.Require(DisplayName);
    }
}