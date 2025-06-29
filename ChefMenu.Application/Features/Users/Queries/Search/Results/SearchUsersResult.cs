using ChefMenu.Application.Core.Results;
using ChefMenu.Application.Features.Users.Queries.Shared;

namespace ChefMenu.Application.Features.Users.Queries.Search.Results;

public sealed class SearchUsersResult : IResult
{
    public required IReadOnlyList<UserResult> Users { get; init; }
}
