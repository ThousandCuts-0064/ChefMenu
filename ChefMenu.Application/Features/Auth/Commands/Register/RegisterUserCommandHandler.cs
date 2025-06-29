using ChefMenu.Application.Core.Commands;
using ChefMenu.Application.Core.Messages;
using ChefMenu.Application.Features.Auth.Commands.Register.Results;
using ChefMenu.Application.Services.Passwords;

namespace ChefMenu.Application.Features.Auth.Commands.Register;

internal sealed class RegisterUserCommandHandler : ICommandHandler<RegisterUserCommand>
{
    private readonly IAppDbContext _appDbContext;
    private readonly IPasswordHasher _passwordHasher;

    public RegisterUserCommandHandler(
        IAppDbContext appDbContext,
        IPasswordHasher passwordHasher)
    {
        _appDbContext = appDbContext;
        _passwordHasher = passwordHasher;
    }

    public async ValueTask<Handled<RegisterUserCommand>> HandleAsync(
        RegisterUserCommand message,
        CancellationToken ct)
    {
        var passwordHash = await _passwordHasher.HashAsync(message.Password);

        var entity = message.ToEntity(passwordHash);

        _appDbContext.Users.Add(entity);

        try
        {
            await _appDbContext.SaveChangesAsync(ct);

            return message.SetResult(new UserCreatedResult
            {
                Id = entity.Id,
                Username = entity.Username,
                Role = entity.Role
            });
        }
        catch(Exception ex)
        {
            return message.SetResult(new UsernameAlreadyExistsResult
            {
                Username = entity.Username
            });
        }
    }
}