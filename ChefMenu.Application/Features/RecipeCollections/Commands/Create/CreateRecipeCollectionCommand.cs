using ChefMenu.Application.Core.Commands;
using ChefMenu.Application.Core.Results;
using ChefMenu.Application.Features.RecipeCollections.Commands.Create.Results;
using ChefMenu.Domain.Features.RecipeCollections;
using ChefMenu.Domain.Features.RecipeCollections.ValueObjects;
using ChefMenu.Domain.Features.Shared.ValueObjects;
using ChefMenu.Domain.Features.Users.ValueObjects;

namespace ChefMenu.Application.Features.RecipeCollections.Commands.Create;

public sealed class CreateRecipeCollectionCommand : Command<CreateRecipeCollectionCommand, Results<
    RecipeCollectionCreatedResult,
    RecipeCollectionNameAlreadyExists>>
{
    public required UserId CreateById { get; init; }
    public required RecipeCollectionName Name { get; init; }
    public required DisplayName DisplayName { get; init; }

    internal RecipeCollection ToEntity() => new()
    {
        CreatedById = CreateById,
        Name = Name,
        DisplayName = DisplayName,
    };
}
