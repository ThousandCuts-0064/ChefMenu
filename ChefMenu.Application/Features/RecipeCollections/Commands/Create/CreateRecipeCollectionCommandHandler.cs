using ChefMenu.Application.Core.Commands;
using ChefMenu.Application.Core.Messages;
using ChefMenu.Application.Features.RecipeCollections.Commands.Create.Results;

namespace ChefMenu.Application.Features.RecipeCollections.Commands.Create;

public sealed class CreateRecipeCollectionCommandHandler : ICommandHandler<CreateRecipeCollectionCommand>
{
    private readonly IAppDbContext _appDbContext;

    public CreateRecipeCollectionCommandHandler(IAppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public async ValueTask<Handled<CreateRecipeCollectionCommand>> HandleAsync(
        CreateRecipeCollectionCommand message,
        CancellationToken ct)
    {
        var entity = message.ToEntity();

        _appDbContext.RecipeCollections.Add(entity);

        try
        {
            await _appDbContext.SaveChangesAsync(ct);

            return message.SetResult(new RecipeCollectionCreatedResult
            {
                Id = entity.Id,
            });
        }
        catch
        {
            return message.SetResult(new RecipeCollectionNameAlreadyExists
            {
                Name = entity.Name,
            });
        }
    }
}