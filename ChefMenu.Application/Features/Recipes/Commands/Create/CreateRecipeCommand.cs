using System.Text.Json;
using ChefMenu.Application.Core.Commands;
using ChefMenu.Application.Core.Results;
using ChefMenu.Application.Features.Recipes.Commands.Create.Results;
using ChefMenu.Domain.Features.Recipes;
using ChefMenu.Domain.Features.Recipes.ValueObjects;
using ChefMenu.Domain.Features.Shared.ValueObjects;
using ChefMenu.Domain.Features.Users.ValueObjects;

namespace ChefMenu.Application.Features.Recipes.Commands.Create;

public sealed class CreateRecipeCommand : Command<CreateRecipeCommand, Results<
    RecipeCreatedResult,
    RecipeNameAlreadyExists>>
{
    public required UserId CreateById { get; init; }
    public required RecipeName Name { get; init; }
    public required DisplayName DisplayName { get; init; }
    public required JsonElement Content { get; set; }

    internal Recipe ToEntity() => new()
    {
        CreatedById = CreateById,
        Name = Name,
        DisplayName = DisplayName,
        Content = Content,
    };
}
