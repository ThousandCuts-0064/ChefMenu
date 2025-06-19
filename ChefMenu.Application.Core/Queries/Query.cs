using ChefMenu.Application.Core.Messages;
using ChefMenu.Application.Core.Results;

namespace ChefMenu.Application.Core.Queries;

public abstract class Query<TSelf, TResult> : Message<TSelf, TResult>, IQuery<TSelf, TResult>
    where TSelf : class, IQuery<TSelf, TResult>
    where TResult : class, IResult;