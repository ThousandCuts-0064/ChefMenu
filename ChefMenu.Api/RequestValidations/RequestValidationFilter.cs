namespace ChefMenu.Api.RequestValidations;

public class RequestValidationFilter : IEndpointFilter
{
    public async ValueTask<object?> InvokeAsync(
        EndpointFilterInvocationContext context,
        EndpointFilterDelegate next)
    {
        var request = context.Arguments
            .OfType<IValidatableRequest>()
            .FirstOrDefault();

        if (request is null)
        {
            return await next(context);
        }

        var validationContext = new RequestValidationContext();

        request.Validate(validationContext);

        if (validationContext.HasErrors(out var problemDetails))
        {
            return TypedResults.Problem(problemDetails);
        }

        return await next(context);
    }
}