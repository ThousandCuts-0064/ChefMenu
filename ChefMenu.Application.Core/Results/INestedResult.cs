namespace ChefMenu.Application.Core.Results;

public interface INestedResult : IResult
{
    public IResult Result { get; }
}