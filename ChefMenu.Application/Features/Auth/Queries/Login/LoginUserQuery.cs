using ChefMenu.Application.Core.Queries;
using ChefMenu.Application.Core.Results;
using ChefMenu.Application.Features.Auth.Queries.Login.Results;
using ChefMenu.Domain.Features.Users.ValueObjects;

namespace ChefMenu.Application.Features.Auth.Queries.Login;

public sealed class LoginUserQuery : Query<LoginUserQuery, Results<
    CorrectUserCredentialsResult,
    IncorrectUserCredentialsResult>>
{
    public required Username Username { get; init; }
    public required Password Password { get; init; }
}
