using ChefMenu.Application.Core.Commands;
using ChefMenu.Application.Core.Queries;
using ChefMenu.Application.Core.Results;
using Microsoft.Extensions.DependencyInjection;

namespace ChefMenu.Application.Core.Mediators;

internal class Mediator : IMediator
{
    private readonly IServiceProvider _serviceProvider;

    public Mediator(IServiceProvider serviceProvider) => _serviceProvider = serviceProvider;

    public async ValueTask<TResult> ExecuteAsync<TCommand, TResult>(
        ICommand<TCommand, TResult> command,
        CancellationToken ct)
        where TCommand : class, ICommand<TCommand, TResult>
        where TResult : class, IResult
    {
        var handler = _serviceProvider.GetRequiredService<ICommandHandler<TCommand>>();

        await handler.HandleAsync((TCommand)command, ct);

        return command.Result;
    }

    public async ValueTask<TResult> FetchAsync<TQuery, TResult>(
        IQuery<TQuery, TResult> query,
        CancellationToken ct)
        where TQuery : class, IQuery<TQuery, TResult>
        where TResult : class, IResult
    {
        var handler = _serviceProvider.GetRequiredService<IQueryHandler<TQuery>>();

        await handler.HandleAsync((TQuery)query, ct);

        return query.Result;
    }
}