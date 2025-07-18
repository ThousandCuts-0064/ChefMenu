﻿using ChefMenu.Api.RequestValidations;
using ChefMenu.Domain.Features.Users.ValueObjects;

namespace ChefMenu.Api.Endpoints.Auth.PostLogin;

public sealed class PostLoginUserRequest : IValidatableRequest
{
    public required Required<Username> Username { get; init; }
    public required Required<Password> Password { get; init; }

    public void Validate(RequestValidationContext context)
    {
        context.Validate(Username);
        context.Validate(Password);
    }
}