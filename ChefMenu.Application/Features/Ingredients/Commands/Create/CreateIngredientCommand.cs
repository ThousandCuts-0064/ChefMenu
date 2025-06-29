using ChefMenu.Application.Core.Commands;
using ChefMenu.Application.Core.Results;
using ChefMenu.Application.Features.Ingredients.Commands.Create.Results;
using ChefMenu.Domain.Features.Ingredients;
using ChefMenu.Domain.Features.Ingredients.ValueObjects;
using ChefMenu.Domain.Features.Shared.ValueObjects;
using ChefMenu.Domain.Features.Users.ValueObjects;

namespace ChefMenu.Application.Features.Ingredients.Commands.Create;

public sealed class CreateIngredientCommand : Command<CreateIngredientCommand, Results<
    IngredientCreatedResult,
    IngredientNameAlreadyExists>>
{
    public required UserId CreateById { get; init; }
    public required IngredientName Name { get; init; }
    public required DisplayName DisplayName { get; init; }

    internal Ingredient ToEntity() => new()
    {
        CreatedById = CreateById,
        Name = Name,
        DisplayName = DisplayName,
    };
}
