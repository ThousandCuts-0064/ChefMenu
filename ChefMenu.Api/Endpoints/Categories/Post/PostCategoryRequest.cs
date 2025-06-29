using ChefMenu.Api.RequestValidations;
using ChefMenu.Domain.Enums;
using ChefMenu.Domain.Features.Categories.ValueObjects;
using ChefMenu.Domain.Features.Shared.ValueObjects;
using ChefMenu.Domain.Features.Users.ValueObjects;

namespace ChefMenu.Api.Endpoints.Categories.Post;

public sealed class PostCategoryRequest : IValidatableRequest
{
    public required Required<UserId> CreateById { get; init; }
    public required Required<CategoryName> Name { get; init; }
    public required Required<DisplayName> DisplayName { get; init; }
    public required CategoryType Type { get; init; }

    public void Validate(RequestValidationContext context)
    {
        context.Validate(CreateById);
        context.Validate(Name);
        context.Validate(DisplayName);
    }
}
