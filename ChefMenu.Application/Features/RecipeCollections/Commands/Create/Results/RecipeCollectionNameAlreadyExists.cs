using ChefMenu.Application.Errors;
using ChefMenu.Application.Features.Shared.Results.Base;
using ChefMenu.Domain.Features.RecipeCollections.ValueObjects;

namespace ChefMenu.Application.Features.RecipeCollections.Commands.Create.Results;

public sealed class RecipeCollectionNameAlreadyExists : NameAlreadyExists<RecipeCollectionName>
{
    public override string ErrorCode => AppErrorCodes.RecipeCollectionNameDuplicate;
    public override string ErrorMessage => $"Recipe Collection Name {Name} already exists.";
}