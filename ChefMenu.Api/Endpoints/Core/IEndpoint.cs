namespace ChefMenu.Api.Endpoints.Core;

public interface IEndpoint
{
    public static abstract IEndpointConventionBuilder Map(IEndpointRouteBuilder builder);
}