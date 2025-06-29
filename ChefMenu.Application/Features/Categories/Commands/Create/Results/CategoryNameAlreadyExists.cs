using ChefMenu.Application.Errors;
using ChefMenu.Application.Features.Shared.Results.Base;
using ChefMenu.Domain.Features.Categories.ValueObjects;

namespace ChefMenu.Application.Features.Categories.Commands.Create.Results;

public sealed class CategoryNameAlreadyExists : NameAlreadyExists<CategoryName>
{
    public override string ErrorCode => AppErrorCodes.CategoryNameDuplicate;
    public override string ErrorMessage => $"Category Name {Name} already exists.";
}