using ChefMenu.Application.Core.Messages;
using ChefMenu.Application.Core.Results;

namespace ChefMenu.Application.Core.Commands;

public interface ICommand<in TSelf, out TResult> : IMessage<TSelf, TResult>
    where TSelf : class, ICommand<TSelf, TResult>
    where TResult : class, IResult;