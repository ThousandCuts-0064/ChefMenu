using ChefMenu.Application.Core.Results;

namespace ChefMenu.Application.Core.Messages;

public interface IMessageHandler<TMessage>
    where TMessage : class, IMessage<TMessage, IResult>
{
    public ValueTask<Handled<TMessage>> HandleAsync(TMessage message, CancellationToken ct);
}