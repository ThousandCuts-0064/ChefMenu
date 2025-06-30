using ChefMenu.Api.RequestValidations;
using ChefMenu.Domain.Features.Ingredients.ValueObjects;
using ChefMenu.Domain.Features.Shared.ValueObjects;
using ChefMenu.Domain.Features.Users.ValueObjects;

namespace ChefMenu.Api.Endpoints.Ingredients.Post;

public sealed class PostIngredientsRequest : IValidatableRequest
{
    public required Required<UserId> CreateById { get; init; }
    public required Required<IngredientName> Name { get; init; }
    public required Required<DisplayName> DisplayName { get; init; }

    public void Validate(RequestValidationContext context)
    {
        context.Validate(CreateById);
        context.Validate(Name);
        context.Validate(DisplayName);
    }
}
