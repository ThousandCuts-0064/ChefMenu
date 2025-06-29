using ChefMenu.Application.Features.Shared.Results.Base;
using ChefMenu.Domain.Features.Recipes.ValueObjects;

namespace ChefMenu.Application.Features.Recipes.Commands.Create.Results;

public sealed class RecipeCreatedResult : CreatedResult<RecipeId>;