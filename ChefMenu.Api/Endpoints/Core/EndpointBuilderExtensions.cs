namespace ChefMenu.Api.Endpoints.Core;

public static class EndpointBuilderExtensions
{
    private const string EndpountGroupSuffix = "EndpointGroup";
    private const string EndpointSuffix = "Endpoint";

    public static RouteGroupBuilder MapEndpointGroup<TEndpointGroup>(this RouteGroupBuilder builder)
        where TEndpointGroup : struct, IEndpointGroup
    {
        var tag = typeof(TEndpointGroup).Name;

        tag = tag.EndsWith(EndpountGroupSuffix)
            ? tag[..^EndpountGroupSuffix.Length]
            : throw new ArgumentOutOfRangeException(nameof(TEndpointGroup), "Unexpected type name suffix");

        TEndpointGroup.Map(builder).WithTags(tag);

        return builder;
    }

    public static RouteGroupBuilder MapEndpoint<TEndpoint>(
        this RouteGroupBuilder builder,
        Action<IEndpointConventionBuilder>? onConfig = null)
        where TEndpoint : struct, IEndpoint
    {
        var name = typeof(TEndpoint).Name;

        name = name.EndsWith(EndpointSuffix)
            ? name[..^EndpointSuffix.Length]
            : throw new ArgumentOutOfRangeException(nameof(TEndpoint), "Unexpected type name suffix");

        var endpoint = TEndpoint.Map(builder).WithName(name);

        onConfig?.Invoke(endpoint);

        return builder;
    }
}