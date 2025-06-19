using ChefMenu.Application.Core.Results;

namespace ChefMenu.Application.Core.Messages;

public struct Handled<TMessage>
    where TMessage : class, IMessage<TMessage, IResult>;