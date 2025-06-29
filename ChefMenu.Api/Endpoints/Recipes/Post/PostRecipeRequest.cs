using System.Text.Json;
using ChefMenu.Api.RequestValidations;
using ChefMenu.Domain.Features.Recipes.ValueObjects;
using ChefMenu.Domain.Features.Shared.ValueObjects;
using ChefMenu.Domain.Features.Users.ValueObjects;

namespace ChefMenu.Api.Endpoints.Recipes.Post;

public sealed class PostRecipeRequest : IValidatableRequest
{
    public required Required<UserId> CreateById { get; init; }
    public required Required<RecipeName> Name { get; init; }
    public required Required<DisplayName> DisplayName { get; init; }
    public required JsonElement Content { get; init; }

    public void Validate(RequestValidationContext context)
    {
        context.Validate(CreateById);
        context.Validate(Name);
        context.Validate(DisplayName);
    }
}
