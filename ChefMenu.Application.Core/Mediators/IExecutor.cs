using ChefMenu.Application.Core.Commands;
using ChefMenu.Application.Core.Results;

namespace ChefMenu.Application.Core.Mediators;

public interface IExecutor
{
    public ValueTask<TResult> ExecuteAsync<TCommand, TResult>(
        ICommand<TCommand, TResult> command,
        CancellationToken ct)
        where TCommand : class, ICommand<TCommand, TResult>
        where TResult : class, IResult;
}