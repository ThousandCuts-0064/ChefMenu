using ChefMenu.Application.Core.Features;
using ChefMenu.Application.Core.Mediators;
using ChefMenu.Application.Features.Auth;
using ChefMenu.Application.Services.Passwords;
using Microsoft.Extensions.DependencyInjection;

namespace ChefMenu.Application.DependencyInjection;

public static class ApplicationServiceCollectionExtensions
{
    public static IServiceCollection AddApplication(this IServiceCollection services, ApplicationOptions options)
    {
        services.AddOptions<PasswordHasherOptions>()
            .BindConfiguration(options.PasswordHasher)
            .ValidateDataAnnotations()
            .ValidateOnStart();

        return services
            .AddMediator()
            .AddScoped<IPasswordHasher, PasswordHasher>()
            .AddFeature<AuthFeature>();
    }
}