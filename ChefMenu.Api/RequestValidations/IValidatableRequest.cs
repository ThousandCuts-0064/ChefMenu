namespace ChefMenu.Api.RequestValidations;

public interface IValidatableRequest
{
    public void Validate(RequestValidationContext context);
}