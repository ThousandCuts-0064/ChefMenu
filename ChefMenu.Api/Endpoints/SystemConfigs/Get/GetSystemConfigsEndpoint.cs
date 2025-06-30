using ChefMenu.Api.Endpoints.Core;
using ChefMenu.Domain.Features.SystemConfigs.ValueObjects;

namespace ChefMenu.Api.Endpoints.SystemConfigs.Get;

public struct GetSystemConfigsEndpoint : IEndpoint
{
    public static IEndpointConventionBuilder Map(IEndpointRouteBuilder builder)
    {
        return builder.MapGet("/{key}", (SystemConfigKey key) => { });
    }
}