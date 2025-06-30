using ChefMenu.Api.Endpoints.Core;
using ChefMenu.Api.Endpoints.SystemConfigs.Get;
using ChefMenu.Api.Endpoints.SystemConfigs.Patch;

namespace ChefMenu.Api.Endpoints.SystemConfigs;

public struct SystemConfigsEndpointGroup : IEndpointGroup
{
    public static RouteGroupBuilder Map(RouteGroupBuilder builder) => builder
        .MapGroup("/system-configs")
        .MapEndpoint<GetSystemConfigsEndpoint>()
        .MapEndpoint<PatchSystemConfigEndpoint>();
}