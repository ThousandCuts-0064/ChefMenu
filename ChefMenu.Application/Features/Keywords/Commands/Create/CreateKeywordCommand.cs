using ChefMenu.Application.Core.Commands;
using ChefMenu.Application.Core.Results;
using ChefMenu.Application.Features.Keywords.Commands.Create.Results;
using ChefMenu.Domain.Features.Keywords;
using ChefMenu.Domain.Features.Keywords.ValueObjects;
using ChefMenu.Domain.Features.Shared.ValueObjects;
using ChefMenu.Domain.Features.Users.ValueObjects;

namespace ChefMenu.Application.Features.Keywords.Commands.Create;

public sealed class CreateKeywordCommand : Command<CreateKeywordCommand, Results<
    KeywordCreatedResult,
    KeywordNameAlreadyExists>>
{
    public required UserId CreateById { get; init; }
    public required KeywordName Name { get; init; }
    public required DisplayName DisplayName { get; init; }

    internal Keyword ToEntity() => new()
    {
        CreatedById = CreateById,
        Name = Name,
        DisplayName = DisplayName,
    };
}
