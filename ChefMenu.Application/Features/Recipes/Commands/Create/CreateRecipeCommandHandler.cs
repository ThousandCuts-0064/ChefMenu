using ChefMenu.Application.Core.Commands;
using ChefMenu.Application.Core.Messages;
using ChefMenu.Application.Features.Recipes.Commands.Create.Results;

namespace ChefMenu.Application.Features.Recipes.Commands.Create;

public sealed class CreateRecipeCommandHandler : ICommandHandler<CreateRecipeCommand>
{
    private readonly IAppDbContext _appDbContext;

    public CreateRecipeCommandHandler(IAppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public async ValueTask<Handled<CreateRecipeCommand>> HandleAsync(
        CreateRecipeCommand message,
        CancellationToken ct)
    {
        var entity = message.ToEntity();

        _appDbContext.Recipes.Add(entity);

        try
        {
            await _appDbContext.SaveChangesAsync(ct);

            return message.SetResult(new RecipeCreatedResult
            {
                Id = entity.Id,
            });
        }
        catch
        {
            return message.SetResult(new RecipeNameAlreadyExists
            {
                Name = entity.Name,
            });
        }
    }
}