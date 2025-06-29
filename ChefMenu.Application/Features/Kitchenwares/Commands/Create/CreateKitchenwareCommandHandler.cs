using ChefMenu.Application.Core.Commands;
using ChefMenu.Application.Core.Messages;
using ChefMenu.Application.Features.Kitchenwares.Commands.Create.Results;

namespace ChefMenu.Application.Features.Kitchenwares.Commands.Create;

public sealed class CreateKitchenwareCommandHandler : ICommandHandler<CreateKitchenwareCommand>
{
    private readonly IAppDbContext _appDbContext;

    public CreateKitchenwareCommandHandler(IAppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public async ValueTask<Handled<CreateKitchenwareCommand>> HandleAsync(
        CreateKitchenwareCommand message,
        CancellationToken ct)
    {
        var entity = message.ToEntity();

        _appDbContext.Kitchenwares.Add(entity);

        try
        {
            await _appDbContext.SaveChangesAsync(ct);

            return message.SetResult(new KitchenwareCreatedResult
            {
                Id = entity.Id,
            });
        }
        catch
        {
            return message.SetResult(new KitchenwareNameAlreadyExists
            {
                Name = entity.Name,
            });
        }
    }
}