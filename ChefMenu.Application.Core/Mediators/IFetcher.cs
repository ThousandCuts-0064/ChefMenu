using ChefMenu.Application.Core.Queries;
using ChefMenu.Application.Core.Results;

namespace ChefMenu.Application.Core.Mediators;

public interface IFetcher
{
    public ValueTask<TResult> FetchAsync<TQuery, TResult>(
        IQuery<TQuery, TResult> query,
        CancellationToken ct)
        where TQuery : class, IQuery<TQuery, TResult>
        where TResult : class, IResult;
}