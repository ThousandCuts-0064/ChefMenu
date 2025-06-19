using ChefMenu.Application.Core.Results;

namespace ChefMenu.Application.Core.Messages;

public interface IMessage<in TSelf, out TResult>
    where TSelf : class, IMessage<TSelf, TResult>
    where TResult : class, IResult
{
    internal TResult Result { get; }
}