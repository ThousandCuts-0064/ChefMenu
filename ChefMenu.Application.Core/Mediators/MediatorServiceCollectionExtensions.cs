using System.Diagnostics.CodeAnalysis;
using ChefMenu.Application.Core.Commands;
using ChefMenu.Application.Core.Queries;
using ChefMenu.Application.Core.Results;
using Microsoft.Extensions.DependencyInjection;

namespace ChefMenu.Application.Core.Mediators;

public static class MediatorServiceCollectionExtensions
{
    public static IServiceCollection AddMediator(this IServiceCollection services)
    {
        return services
            .AddScoped<IExecutor, Mediator>()
            .AddScoped<IFetcher, Mediator>()
            .AddScoped<IMediator, Mediator>();
    }

    public static IServiceCollection AddCommand<
        TCommand,
        [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TCommandHandler>(
        this IServiceCollection services)
        where TCommand : class, ICommand<TCommand, IResult>
        where TCommandHandler : class, ICommandHandler<TCommand>
    {
        return services.AddTransient<ICommandHandler<TCommand>, TCommandHandler>();
    }

    public static IServiceCollection AddQuery<
        TQuery,
        [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TQueryHandler>(
        this IServiceCollection services)
        where TQuery : class, IQuery<TQuery, IResult>
        where TQueryHandler : class, IQueryHandler<TQuery>
    {
        return services.AddTransient<IQueryHandler<TQuery>, TQueryHandler>();
    }
}