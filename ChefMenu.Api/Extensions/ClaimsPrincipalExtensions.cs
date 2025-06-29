using System.Diagnostics;
using System.Security.Claims;
using ChefMenu.Domain.Enums;
using ChefMenu.Domain.Features.Users.ValueObjects;

namespace ChefMenu.Api.Extensions;

public static class ClaimsPrincipalExtensions
{
    public static UserId GetUserId(this ClaimsPrincipal principal)
    {
        return UserId.Parse(
            principal.FindFirstValue(ClaimTypes.NameIdentifier)
            ?? throw new UnreachableException());
    }

    public static Username GetUsername(this ClaimsPrincipal principal)
    {
        return Username.Create(
            principal.FindFirstValue(ClaimTypes.Name)
            ?? throw new UnreachableException());
    }

    public static UserRole GetUserRole(this ClaimsPrincipal principal)
    {
        var role = principal.FindFirstValue(ClaimTypes.Role);

        return role is null
            ? throw new UnreachableException()
            : Enum.Parse<UserRole>(role);
    }

    public static UserRole? GetUserRoleOrNull(this ClaimsPrincipal principal)
    {
        var role = principal.FindFirstValue(ClaimTypes.Role);

        return role is null
            ? null
            : Enum.Parse<UserRole>(role);
    }
}