using System.Runtime.CompilerServices;
using ChefMenu.Domain.Features.Core.ValueObjects;

namespace ChefMenu.Api.Extensions;

public static class NullableExtensions
{
    public static T Require<T>(
        this T? nullable,
        [CallerArgumentExpression(nameof(nullable))] string expression = null!)
        where T : struct, IValueObject
    {
        return nullable ?? throw new ArgumentNullException(expression);
    }
}