using ChefMenu.Application.Core.Messages;
using ChefMenu.Application.Core.Queries;
using ChefMenu.Application.Features.Shared.Results;
using ChefMenu.Application.Features.Users.Queries.Shared;
using ChefMenu.Domain.Enums;
using Microsoft.EntityFrameworkCore;

namespace ChefMenu.Application.Features.Users.Queries.Get;

public sealed class GetUserQueryHander : IQueryHandler<GetUserQuery>
{
    private readonly IAppDbContext _appDbContext;

    public GetUserQueryHander(IAppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public async ValueTask<Handled<GetUserQuery>> HandleAsync(
        GetUserQuery message,
        CancellationToken ct)
    {
        var result = await _appDbContext.Users
            .Where(x =>
                x.Id == message.Id
                && x.IsPublic || message.MeRole >= UserRole.Moderator)
            .Select(UserResult.FromEntity)
            .FirstOrDefaultAsync(ct);

        if (result is null)
        {
            return message.SetResult(new UserIdNotFoundResult
            {
                Id = message.Id
            });
        }

        return message.SetResult(result);
    }
}