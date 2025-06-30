using ChefMenu.Application.Core.Commands;
using ChefMenu.Application.Core.Messages;
using ChefMenu.Application.Features.Categories.Commands.Create.Results;

namespace ChefMenu.Application.Features.Categories.Commands.Create;

public sealed class CreateCategoryCommandHandler : ICommandHandler<CreateCategoryCommand>
{
    private readonly IAppDbContext _appDbContext;

    public CreateCategoryCommandHandler(IAppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public async ValueTask<Handled<CreateCategoryCommand>> HandleAsync(
        CreateCategoryCommand message,
        CancellationToken ct)
    {
        var entity = message.ToEntity();

        _appDbContext.Categories.Add(entity);

        try
        {
            await _appDbContext.SaveChangesAsync(ct);

            return message.SetResult(new CategoryCreatedResult
            {
                Id = entity.Id,
            });
        }
        catch(Exception ex)
        {
            return message.SetResult(new CategoryNameAlreadyExists
            {
                Name = entity.Name,
            });
        }
    }
}