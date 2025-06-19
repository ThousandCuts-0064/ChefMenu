using System.Text.Json.Serialization;
using ChefMenu.Api.Endpoints.Auth.Login;
using ChefMenu.Api.Endpoints.Auth.Register;
using ChefMenu.Api.JsonSerialization.JsonSerializerContexts;

namespace ChefMenu.Api.Endpoints.Auth;

[JsonSerializable(typeof(RegisterUserRequest))]
[JsonSerializable(typeof(LoginUserRequest))]
internal sealed partial class AuthJsonSerializerContext : ApiJsonSerializerContext;