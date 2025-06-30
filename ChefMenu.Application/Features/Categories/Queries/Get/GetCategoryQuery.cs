using ChefMenu.Application.Core.Queries;
using ChefMenu.Application.Core.Results;
using ChefMenu.Application.Features.Categories.Queries.Get.Results;
using ChefMenu.Domain.Features.Categories.ValueObjects;

namespace ChefMenu.Application.Features.Categories.Queries.Get;

public sealed class GetCategoryQuery : Query<GetCategoryQuery, Results<
    CategoryResult,
    CategoryIdNotFoundResult>>
{
    public required CategoryId Id { get; init; }
}