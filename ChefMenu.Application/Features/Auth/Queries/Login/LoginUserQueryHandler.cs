using ChefMenu.Application.Core.Messages;
using ChefMenu.Application.Core.Queries;
using ChefMenu.Application.Features.Auth.Queries.Login.Results;
using ChefMenu.Application.Services.Passwords;
using Microsoft.EntityFrameworkCore;

namespace ChefMenu.Application.Features.Auth.Queries.Login;

internal sealed class LoginUserQueryHandler : IQueryHandler<LoginUserQuery>
{
    private readonly IAppDbContext _appDbContext;
    private readonly IPasswordHasher _passwordHasher;

    public LoginUserQueryHandler(
        IAppDbContext appDbContext,
        IPasswordHasher passwordHasher)
    {
        _appDbContext = appDbContext;
        _passwordHasher = passwordHasher;
    }

    public async ValueTask<Handled<LoginUserQuery>> HandleAsync(
        LoginUserQuery message,
        CancellationToken ct)
    {
        var user = await _appDbContext.Users
            .FirstOrDefaultAsync(x => x.Username == message.Username, ct);

        if (user is null)
        {
            return message.SetResult(new IncorrectUserCredentialsResult());
        }

        var isPasswordCorerct = await _passwordHasher
            .IsCorrectAsync(message.Password, user.PasswordHash);

        if (!isPasswordCorerct)
        {
            return message.SetResult(new IncorrectUserCredentialsResult());
        }

        return message.SetResult(new CorrectUserCredentialsResult
        {
            Id = user.Id,
            Username = message.Username,
            Role = user.Role,
        });
    }
}