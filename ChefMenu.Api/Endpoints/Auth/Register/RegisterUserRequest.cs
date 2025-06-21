using ChefMenu.Api.RequestValidations;
using ChefMenu.Domain.Features.Shared.ValueObjects;
using ChefMenu.Domain.Features.Users.ValueObjects;

namespace ChefMenu.Api.Endpoints.Auth.Register;

public sealed class RegisterUserRequest : IValidatableRequest
{
    public required Required<Username> Username { get; init; }
    public required Required<Email> Email { get; init; }
    public required Required<Password> Password { get; init; }
    public required Required<DisplayName> DisplayName { get; init; }

    public void Validate(RequestValidationContext context)
    {
        context.Validate(Username);
        context.Validate(Email);
        context.Validate(Password);
        context.Validate(DisplayName);
    }
}