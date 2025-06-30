using ChefMenu.Api.RequestValidations;
using ChefMenu.Domain.Features.Keywords.ValueObjects;
using ChefMenu.Domain.Features.Shared.ValueObjects;
using ChefMenu.Domain.Features.Users.ValueObjects;

namespace ChefMenu.Api.Endpoints.Keywords.Post;

public sealed class PostKeywordsRequest : IValidatableRequest
{
    public required Required<UserId> CreateById { get; init; }
    public required Required<KeywordName> Name { get; init; }
    public required Required<DisplayName> DisplayName { get; init; }

    public void Validate(RequestValidationContext context)
    {
        context.Validate(CreateById);
        context.Validate(Name);
        context.Validate(DisplayName);
    }
}
