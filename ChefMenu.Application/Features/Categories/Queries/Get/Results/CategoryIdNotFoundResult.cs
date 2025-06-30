using ChefMenu.Application.Errors;
using ChefMenu.Application.Features.Shared.Results.Base;
using ChefMenu.Domain.Features.Categories.ValueObjects;

namespace ChefMenu.Application.Features.Categories.Queries.Get.Results;

public sealed class CategoryIdNotFoundResult : IdNotFoundResult<CategoryId>
{
    public override string ErrorCode => AppErrorCodes.CategoryIdNotFound;
    public override string ErrorMessage => $"Category Id {Id} not found.";
}
