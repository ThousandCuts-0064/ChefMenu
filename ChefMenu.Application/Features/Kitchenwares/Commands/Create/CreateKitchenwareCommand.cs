using ChefMenu.Application.Core.Commands;
using ChefMenu.Application.Core.Results;
using ChefMenu.Application.Features.Kitchenwares.Commands.Create.Results;
using ChefMenu.Domain.Features.Kitchenwares;
using ChefMenu.Domain.Features.Kitchenwares.ValueObjects;
using ChefMenu.Domain.Features.Shared.ValueObjects;
using ChefMenu.Domain.Features.Users.ValueObjects;

namespace ChefMenu.Application.Features.Kitchenwares.Commands.Create;

public sealed class CreateKitchenwareCommand : Command<CreateKitchenwareCommand, Results<
    KitchenwareCreatedResult,
    KitchenwareNameAlreadyExists>>
{
    public required UserId CreateById { get; init; }
    public required KitchenwareName Name { get; init; }
    public required DisplayName DisplayName { get; init; }

    internal Kitchenware ToEntity() => new()
    {
        CreatedById = CreateById,
        Name = Name,
        DisplayName = DisplayName,
    };
}
