using ChefMenu.Application.Errors;
using ChefMenu.Application.Features.Shared.Results.Base;
using ChefMenu.Domain.Features.Keywords.ValueObjects;

namespace ChefMenu.Application.Features.Keywords.Commands.Create.Results;

public sealed class KeywordNameAlreadyExists : NameAlreadyExists<KeywordName>
{
    public override string ErrorCode => AppErrorCodes.KeywordNameDuplicate;
    public override string ErrorMessage => $"Keyword Name {Name} already exists.";
}