using ChefMenu.Api.Endpoints.Core;
using ChefMenu.Domain.Features.SystemActionHistories.ValueObjects;

namespace ChefMenu.Api.Endpoints.Me.GetTypeCreated;

public struct GetMeTypeCreatedEndpoint : IEndpoint
{
    public static IEndpointConventionBuilder Map(IEndpointRouteBuilder builder)
    {
        return builder.MapGet("{type}", (EntityName type) => { });
    }
}