namespace ChefMenu.Api.RequestValidations;

public readonly record struct ValidationError
{
    public required string ErrorCode { get; init; }
    public required string ErrorMessage { get; init; }
}