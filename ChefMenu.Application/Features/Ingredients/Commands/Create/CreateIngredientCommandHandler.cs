using ChefMenu.Application.Core.Commands;
using ChefMenu.Application.Core.Messages;
using ChefMenu.Application.Features.Ingredients.Commands.Create.Results;

namespace ChefMenu.Application.Features.Ingredients.Commands.Create;

public sealed class CreateIngredientCommandHandler : ICommandHandler<CreateIngredientCommand>
{
    private readonly IAppDbContext _appDbContext;

    public CreateIngredientCommandHandler(IAppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public async ValueTask<Handled<CreateIngredientCommand>> HandleAsync(
        CreateIngredientCommand message,
        CancellationToken ct)
    {
        var entity = message.ToEntity();

        _appDbContext.Ingredients.Add(entity);

        try
        {
            await _appDbContext.SaveChangesAsync(ct);

            return message.SetResult(new IngredientCreatedResult
            {
                Id = entity.Id,
            });
        }
        catch
        {
            return message.SetResult(new IngredientNameAlreadyExists
            {
                Name = entity.Name,
            });
        }
    }
}