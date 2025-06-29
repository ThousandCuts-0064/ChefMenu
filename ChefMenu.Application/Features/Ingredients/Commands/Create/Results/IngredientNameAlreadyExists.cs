using ChefMenu.Application.Errors;
using ChefMenu.Application.Features.Shared.Results.Base;
using ChefMenu.Domain.Features.Ingredients.ValueObjects;

namespace ChefMenu.Application.Features.Ingredients.Commands.Create.Results;

public sealed class IngredientNameAlreadyExists : NameAlreadyExists<IngredientName>
{
    public override string ErrorCode => AppErrorCodes.IngredientNameDuplicate;
    public override string ErrorMessage => $"Ingredient Name {Name} already exists.";
}