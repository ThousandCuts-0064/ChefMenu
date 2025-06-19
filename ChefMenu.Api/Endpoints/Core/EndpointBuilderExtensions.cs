namespace ChefMenu.Api.Endpoints.Core;

public static class EndpointBuilderExtensions
{
    public static RouteGroupBuilder MapEndpointGroup<TEndpointGroup>(this RouteGroupBuilder builder)
        where TEndpointGroup : struct, IEndpointGroup
    {
        TEndpointGroup.Map(builder);

        return builder;
    }

    public static IEndpointRouteBuilder MapEndpoint<TEndpoint>(this IEndpointRouteBuilder builder)
        where TEndpoint : struct, IEndpoint
    {
        TEndpoint.Map(builder);

        return builder;
    }
}