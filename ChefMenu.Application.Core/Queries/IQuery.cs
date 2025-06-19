using ChefMenu.Application.Core.Messages;
using ChefMenu.Application.Core.Results;

namespace ChefMenu.Application.Core.Queries;

public interface IQuery<in TSelf, out TResult> : IMessage<TSelf, TResult>
    where TSelf : class, IQuery<TSelf, TResult>
    where TResult : class, IResult;