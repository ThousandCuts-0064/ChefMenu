using ChefMenu.Application.Core.Messages;
using ChefMenu.Application.Core.Results;

namespace ChefMenu.Application.Core.Commands;

public abstract class Command<TSelf, TResult> : Message<TSelf, TResult>, ICommand<TSelf, TResult>
    where TSelf : class, ICommand<TSelf, TResult>
    where TResult : class, IResult;