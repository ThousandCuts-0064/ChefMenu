using ChefMenu.Application.Core.Messages;
using ChefMenu.Application.Core.Queries;
using ChefMenu.Application.Features.Categories.Queries.Get.Results;
using Microsoft.EntityFrameworkCore;

namespace ChefMenu.Application.Features.Categories.Queries.Get;

public sealed class GetCategoryQueryHander : IQueryHandler<GetCategoryQuery>
{
    private readonly IAppDbContext _appDbContext;

    public GetCategoryQueryHander(IAppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public async ValueTask<Handled<GetCategoryQuery>> HandleAsync(
        GetCategoryQuery message,
        CancellationToken ct)
    {
        var result = await _appDbContext.Categories
            .Where(x => x.Id == message.Id)
            .Select(CategoryResult.FromEntity)
            .FirstOrDefaultAsync(ct);

        if (result is null)
        {
            return message.SetResult(new CategoryIdNotFoundResult
            {
                Id = message.Id
            });
        }

        return message.SetResult(result);
    }
}