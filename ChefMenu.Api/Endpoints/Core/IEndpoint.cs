namespace ChefMenu.Api.Endpoints.Core;

public interface IEndpoint
{
    public static abstract void Map(IEndpointRouteBuilder builder);
}