using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using ChefMenu.Domain.Features.Core.ValueObjects;

namespace ChefMenu.Api.RequestValidations;

public class RequestValidationContext
{
    private readonly Dictionary<string, List<ValidationError>> _errors = [];

    public void Require<TValueObject>(
        TValueObject? valueObject,
        [CallerArgumentExpression(nameof(valueObject))] string expression = null!)
        where TValueObject : struct, IValueObject
    {
        if (valueObject is not null)
        {
            return;
        }

        var error = new ValidationError
        {
            ErrorCode = TValueObject.ErrorCode,
            ErrorMessage = TValueObject.ErrorMessage
        };

        if (_errors.TryGetValue(expression, out var list))
        {
            list.Add(error);

            return;
        }

        _errors.Add(expression, [error]);
    }

    public bool HasErrors([NotNullWhen(true)] out HttpValidationProblemDetails? problemDetails)
    {
        problemDetails = null;

        if (_errors.Count == 0)
        {
            return false;
        }

        problemDetails = new HttpValidationProblemDetails
        {
            Title = "Validation problem(s) occured",
            Extensions = new Dictionary<string, object?>
            {
                ["errors"] = _errors
            }
        };

        return true;
    }
}