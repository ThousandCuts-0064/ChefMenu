using ChefMenu.Api.Endpoints.Core;
using ChefMenu.Api.Endpoints.Me.Get;

namespace ChefMenu.Api.Endpoints.Me;

public struct MeEndpointGroup : IEndpointGroup
{
    public static RouteGroupBuilder Map(RouteGroupBuilder builder) => builder
        .MapGroup("/me")
        .MapEndpoint<GetMeEndpoint>();
}