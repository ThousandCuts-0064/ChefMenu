using ChefMenu.Application.Core.Messages;
using ChefMenu.Application.Core.Results;

namespace ChefMenu.Application.Core.Queries;

public interface IQueryHandler<TQuery> : IMessageHandler<TQuery>
    where TQuery : class, IQuery<TQuery, IResult>;