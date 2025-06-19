using ChefMenu.Application.Services.Passwords;

namespace ChefMenu.Application.DependencyInjection;

public sealed class ApplicationOptions
{
    /// <summary>
    /// Section name for <see cref="PasswordHasherOptions"/>
    /// </summary>
    public required string PasswordHasher { get; init; }
}