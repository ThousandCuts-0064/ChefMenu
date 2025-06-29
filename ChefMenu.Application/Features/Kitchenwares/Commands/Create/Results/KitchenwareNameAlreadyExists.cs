using ChefMenu.Application.Errors;
using ChefMenu.Application.Features.Shared.Results.Base;
using ChefMenu.Domain.Features.Kitchenwares.ValueObjects;

namespace ChefMenu.Application.Features.Kitchenwares.Commands.Create.Results;

public sealed class KitchenwareNameAlreadyExists : NameAlreadyExists<KitchenwareName>
{
    public override string ErrorCode => AppErrorCodes.KitchenwareNameDuplicate;
    public override string ErrorMessage => $"Kitchenware Name {Name} already exists.";
}