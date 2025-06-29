using ChefMenu.Application.Core.Messages;
using ChefMenu.Application.Core.Queries;
using ChefMenu.Application.Features.Users.Queries.Search.Results;
using ChefMenu.Application.Features.Users.Queries.Shared;
using ChefMenu.Application.ValueObjects;
using ChefMenu.Domain.Enums;
using Microsoft.EntityFrameworkCore;

namespace ChefMenu.Application.Features.Users.Queries.Search;

public sealed class SearchUsersQueryHander : IQueryHandler<SearchUsersQuery>
{
    private readonly IAppDbContext _appDbContext;

    public SearchUsersQueryHander(IAppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public async ValueTask<Handled<SearchUsersQuery>> HandleAsync(
        SearchUsersQuery message,
        CancellationToken ct)
    {
        var results = await _appDbContext.Users
            .Where(x =>
                x.Role != UserRole.System
                && x.IsPublic || message.MeRole >= UserRole.Moderator)
            .OrderBy(x => EF.Functions.TrigramsSimilarityDistance(x.Username, message.Username ?? ""))
            .Take(message.PageSize ?? PageSize.Default)
            .OrderBy(x => EF.Functions.FuzzyStringMatchLevenshtein(x.Username, message.Username ?? ""))
            .Select(UserResult.FromEntity)
            .ToListAsync(ct);

        return message.SetResult(new SearchUsersResult
        {
            Users = results
        });
    }
}