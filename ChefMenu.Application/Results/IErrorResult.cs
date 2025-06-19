using ChefMenu.Application.Core.Results;

namespace ChefMenu.Application.Results;

public interface IErrorResult : IResult
{
    public string ErrorCode { get; }
    public string ErrorMessage { get; }
}