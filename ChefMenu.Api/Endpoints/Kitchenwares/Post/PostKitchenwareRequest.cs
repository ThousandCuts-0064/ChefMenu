using ChefMenu.Api.RequestValidations;
using ChefMenu.Domain.Features.Kitchenwares.ValueObjects;
using ChefMenu.Domain.Features.Shared.ValueObjects;
using ChefMenu.Domain.Features.Users.ValueObjects;

namespace ChefMenu.Api.Endpoints.Kitchenwares.Post;

public sealed class PostKitchenwareRequest : IValidatableRequest
{
    public required Required<UserId> CreateById { get; init; }
    public required Required<KitchenwareName> Name { get; init; }
    public required Required<DisplayName> DisplayName { get; init; }

    public void Validate(RequestValidationContext context)
    {
        context.Validate(CreateById);
        context.Validate(Name);
        context.Validate(DisplayName);
    }
}
