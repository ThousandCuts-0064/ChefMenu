using ChefMenu.Domain.Features.Users.ValueObjects;

namespace ChefMenu.Application.Services.Passwords;

public interface IPasswordHasher
{
    Task<PasswordHash> HashAsync(Password password);
    Task<bool> IsCorrectAsync(Password password, PasswordHash passwordHash);
}