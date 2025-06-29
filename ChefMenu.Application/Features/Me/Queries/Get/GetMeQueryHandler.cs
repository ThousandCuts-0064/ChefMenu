using ChefMenu.Application.Core.Messages;
using ChefMenu.Application.Core.Queries;
using ChefMenu.Application.Features.Me.Queries.Get.Results;
using ChefMenu.Application.Features.Shared.Results;
using Microsoft.EntityFrameworkCore;

namespace ChefMenu.Application.Features.Me.Queries.Get;

public sealed class GetMeQueryHandler : IQueryHandler<GetMeQuery>
{
    private readonly IAppDbContext _appDbContext;

    public GetMeQueryHandler(IAppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public async ValueTask<Handled<GetMeQuery>> HandleAsync(GetMeQuery message, CancellationToken ct)
    {
        var result = await _appDbContext.Users
            .Where(x => x.Id == message.Id)
            .Select(MeResult.FromEntity)
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
