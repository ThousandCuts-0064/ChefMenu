using ChefMenu.Application.Core.Results;

namespace ChefMenu.Application.Core.Messages;

public abstract class Message<TSelf, TResult> : IMessage<TSelf, TResult>
    where TSelf : class, IMessage<TSelf, TResult>
    where TResult : class, IResult
{
    private TResult? _result;

    TResult IMessage<TSelf, TResult>.Result => _result
        ?? throw new InvalidOperationException($"{typeof(TSelf).Name} was not handled");

    public Handled<TSelf> SetResult(TResult result)
    {
        _result = result;

        return default;
    }
}