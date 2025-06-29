using ChefMenu.Application.Errors;
using ChefMenu.Application.Features.Shared.Results.Base;
using ChefMenu.Domain.Features.Recipes.ValueObjects;

namespace ChefMenu.Application.Features.Recipes.Commands.Create.Results;

public sealed class RecipeNameAlreadyExists : NameAlreadyExists<RecipeName>
{
    public override string ErrorCode => AppErrorCodes.RecipeNameDuplicate;
    public override string ErrorMessage => $"Recipe Name {Name} already exists.";
}