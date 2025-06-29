using ChefMenu.Application.Core.Results;

namespace ChefMenu.Application.Features.Shared.Results;

public sealed class SuccessResult : IResult
{
    public static SuccessResult Instance { get; } = new();

    private SuccessResult() { }
}