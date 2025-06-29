using ChefMenu.Application.Core.Queries;
using ChefMenu.Application.Core.Results;
using ChefMenu.Application.Features.Me.Queries.Get.Results;
using ChefMenu.Application.Features.Shared.Results;
using ChefMenu.Domain.Features.Users.ValueObjects;

namespace ChefMenu.Application.Features.Me.Queries.Get;
public sealed class GetMeQuery : Query<GetMeQuery, Results<
    MeResult,
    UserIdNotFoundResult>>
{
    public required UserId Id { get; init; }
}
