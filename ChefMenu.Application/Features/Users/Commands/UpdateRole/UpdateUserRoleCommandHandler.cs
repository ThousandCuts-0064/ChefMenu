using ChefMenu.Application.Core.Commands;
using ChefMenu.Application.Core.Messages;
using ChefMenu.Application.Features.Shared.Results;
using ChefMenu.Application.Features.Users.Commands.UpdateRole.Results;
using ChefMenu.Application.Services.DateTimeProvider;
using Microsoft.EntityFrameworkCore;

namespace ChefMenu.Application.Features.Users.Commands.UpdateRole;

internal class UpdateUserRoleCommandHandler : ICommandHandler<UpdateUserRoleCommand>
{
    private readonly IAppDbContext _appDbContext;
    private readonly IDateTimeProvider _dateTimeProvider;

    public UpdateUserRoleCommandHandler(
        IAppDbContext appDbContext,
        IDateTimeProvider dateTimeProvider)
    {
        _appDbContext = appDbContext;
        _dateTimeProvider = dateTimeProvider;
    }

    public async ValueTask<Handled<UpdateUserRoleCommand>> HandleAsync(
        UpdateUserRoleCommand message,
        CancellationToken ct)
    {
        if (message.MeId == message.UserId)
        {
            return message.SetResult(UserIdCannotBeMeResult.Instance);
        }

        var entity = await _appDbContext.Users
            .AsTracking()
            .FirstOrDefaultAsync(x => x.Id == message.UserId, ct);

        if (message.MeRole <= message.NewUserRole)
        {
            return message.SetResult(new InsufficientUserRoleResult
            {
                Role = message.MeRole
            });
        }

        if (entity is null)
        {
            return message.SetResult(new UserIdNotFoundResult
            {
                Id = message.UserId
            });
        }

        entity.Role = message.NewUserRole;
        entity.UpdatedAt = _dateTimeProvider.UtcNow;
        entity.UpdatedById = message.MeId;

        await _appDbContext.SaveChangesAsync(ct);

        return message.SetResult(SuccessResult.Instance);
    }
}