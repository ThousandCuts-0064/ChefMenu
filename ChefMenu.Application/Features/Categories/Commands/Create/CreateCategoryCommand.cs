using ChefMenu.Application.Core.Commands;
using ChefMenu.Application.Core.Results;
using ChefMenu.Application.Features.Categories.Commands.Create.Results;
using ChefMenu.Domain.Enums;
using ChefMenu.Domain.Features.Categories;
using ChefMenu.Domain.Features.Categories.ValueObjects;
using ChefMenu.Domain.Features.Shared.ValueObjects;
using ChefMenu.Domain.Features.Users.ValueObjects;

namespace ChefMenu.Application.Features.Categories.Commands.Create;

public sealed class CreateCategoryCommand : Command<CreateCategoryCommand, Results<
    CategoryCreatedResult,
    CategoryNameAlreadyExists>>
{
    public required UserId CreateById { get; init; }
    public required CategoryName Name { get; init; }
    public required DisplayName DisplayName { get; init; }
    public required CategoryType Type { get; init; }

    internal Category ToEntity() => new()
    {
        CreatedById = CreateById,
        Name = Name,
        DisplayName = DisplayName,
        Type = Type,
    };
}
