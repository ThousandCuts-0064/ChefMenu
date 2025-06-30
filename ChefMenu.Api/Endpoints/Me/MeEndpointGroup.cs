using ChefMenu.Api.Endpoints.Core;
using ChefMenu.Api.Endpoints.Me.Delete;
using ChefMenu.Api.Endpoints.Me.DeleteActions;
using ChefMenu.Api.Endpoints.Me.Get;
using ChefMenu.Api.Endpoints.Me.GetActions;
using ChefMenu.Api.Endpoints.Me.GetMeCommentsReceived;
using ChefMenu.Api.Endpoints.Me.GetTypeCreated;
using ChefMenu.Api.Endpoints.Me.Patch;
using ChefMenu.Api.Endpoints.Me.PatchActions;
using ChefMenu.Api.Endpoints.Me.PostActions;

namespace ChefMenu.Api.Endpoints.Me;

public struct MeEndpointGroup : IEndpointGroup
{
    public static RouteGroupBuilder Map(RouteGroupBuilder builder) => builder
        .MapGroup("/me")
        .MapEndpoint<GetMeEndpoint>()
        .MapEndpoint<PatchMeEndpoint>()
        .MapEndpoint<DeleteMeEndpoint>()
        .MapEndpoint<GetMeTypeCreatedEndpoint>()
        .MapEndpoint<GetMeCommentsReceivedEndpoint>()
        .MapEndpoint<GetMeActionsEndpoint>()
        .MapEndpoint<PostMeActionsEndpoint>()
        .MapEndpoint<PatchMeActionsEndpoint>()
        .MapEndpoint<DeleteMeActionsEndpoint>();
}