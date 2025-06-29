using ChefMenu.Application.Core.Queries;
using ChefMenu.Application.Core.Results;
using ChefMenu.Application.Features.Shared.Results;
using ChefMenu.Application.Features.Users.Queries.Shared;
using ChefMenu.Domain.Enums;
using ChefMenu.Domain.Features.Users.ValueObjects;

namespace ChefMenu.Application.Features.Users.Queries.Get;

public sealed class GetUserQuery : Query<GetUserQuery, Results<
    UserResult,
    UserIdNotFoundResult>>
{
    public required UserRole? MeRole { get; init; }
    public required UserId Id { get; init; }
}