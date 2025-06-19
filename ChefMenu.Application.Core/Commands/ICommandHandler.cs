using ChefMenu.Application.Core.Messages;
using ChefMenu.Application.Core.Results;

namespace ChefMenu.Application.Core.Commands;

public interface ICommandHandler<TCommand> : IMessageHandler<TCommand>
    where TCommand : class, ICommand<TCommand, IResult>;