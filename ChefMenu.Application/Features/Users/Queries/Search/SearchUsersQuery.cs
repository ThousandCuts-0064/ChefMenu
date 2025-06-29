using ChefMenu.Application.Core.Queries;
using ChefMenu.Application.Features.Users.Queries.Search.Results;
using ChefMenu.Application.ValueObjects;
using ChefMenu.Domain.Enums;
using ChefMenu.Domain.Features.Users.ValueObjects;

namespace ChefMenu.Application.Features.Users.Queries.Search;

public sealed class SearchUsersQuery : Query<SearchUsersQuery, SearchUsersResult>
{
    public required UserRole? MeRole { get; init; }
    public required Username? Username { get; init; }
    public required PageSize? PageSize { get; init; }
}