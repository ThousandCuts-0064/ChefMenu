namespace ChefMenu.Api.Endpoints.Core;

public interface IEndpointGroup
{
    public static abstract RouteGroupBuilder Map(RouteGroupBuilder builder);
}