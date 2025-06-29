using ChefMenu.Application.Features.Shared.Results.Base;
using ChefMenu.Domain.Features.Ingredients.ValueObjects;

namespace ChefMenu.Application.Features.Ingredients.Commands.Create.Results;

public sealed class IngredientCreatedResult : CreatedResult<IngredientId>;