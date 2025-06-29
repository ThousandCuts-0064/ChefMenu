using System.Text.Json.Serialization;
using ChefMenu.Api.RequestValidations;
using ChefMenu.Application.Features.Shared.Results;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace ChefMenu.Api.JsonSerialization.JsonSerializerContexts;

[JsonSerializable(typeof(HttpValidationProblemDetails))]
[JsonSerializable(typeof(ProblemDetails))]
[JsonSerializable(typeof(ProblemHttpResult))]
[JsonSerializable(typeof(SignInHttpResult))]
[JsonSerializable(typeof(UnauthorizedHttpResult))]
[JsonSerializable(typeof(Dictionary<string, List<ValidationError>>))]
[JsonSerializable(typeof(SuccessResult))]
[JsonSerializable(typeof(InsufficientUserRoleResult))]
[JsonSerializable(typeof(UserIdNotFoundResult))]
internal sealed partial class ResultJsonSerializerContext : ApiJsonSerializerContext;