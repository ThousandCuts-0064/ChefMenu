using System.Text.Json.Serialization;
using ChefMenu.Api.RequestValidations;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace ChefMenu.Api.JsonSerialization.JsonSerializerContexts;

[JsonSerializable(typeof(HttpValidationProblemDetails))]
[JsonSerializable(typeof(ProblemDetails))]
[JsonSerializable(typeof(Dictionary<string, List<ValidationError>>))]
[JsonSerializable(typeof(ProblemHttpResult))]
[JsonSerializable(typeof(SignInHttpResult))]
[JsonSerializable(typeof(UnauthorizedHttpResult))]
internal sealed partial class HttpResultJsonSerializerContext : ApiJsonSerializerContext;