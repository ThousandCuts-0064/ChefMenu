using ChefMenu.Application.Core.Commands;
using ChefMenu.Application.Core.Messages;
using ChefMenu.Application.Features.Keywords.Commands.Create.Results;

namespace ChefMenu.Application.Features.Keywords.Commands.Create;

public sealed class CreateKeywordCommandHandler : ICommandHandler<CreateKeywordCommand>
{
    private readonly IAppDbContext _appDbContext;

    public CreateKeywordCommandHandler(IAppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public async ValueTask<Handled<CreateKeywordCommand>> HandleAsync(
        CreateKeywordCommand message,
        CancellationToken ct)
    {
        var entity = message.ToEntity();

        _appDbContext.Keywords.Add(entity);

        try
        {
            await _appDbContext.SaveChangesAsync(ct);

            return message.SetResult(new KeywordCreatedResult
            {
                Id = entity.Id,
            });
        }
        catch
        {
            return message.SetResult(new KeywordNameAlreadyExists
            {
                Name = entity.Name,
            });
        }
    }
}