using ChefMenu.Api.Endpoints.Core;
using ChefMenu.Domain.Features.SystemConfigs.ValueObjects;

namespace ChefMenu.Api.Endpoints.SystemConfigs.Patch;

public struct PatchSystemConfigEndpoint : IEndpoint
{
    public static IEndpointConventionBuilder Map(IEndpointRouteBuilder builder)
    {
        return builder.MapPatch("/{key}", (SystemConfigKey key) => { });
    }
}