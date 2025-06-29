using System.Text.Json.Serialization;
using ChefMenu.Api.Endpoints.Auth.PostLogin;
using ChefMenu.Api.Endpoints.Auth.PostRegister;
using ChefMenu.Api.JsonSerialization.JsonSerializerContexts;
using ChefMenu.Application.Features.Auth.Commands.Register.Results;

namespace ChefMenu.Api.Endpoints.Auth;

[JsonSerializable(typeof(PostRegisterUserRequest))]
[JsonSerializable(typeof(UsernameAlreadyExistsResult))]
[JsonSerializable(typeof(PostLoginUserRequest))]
internal sealed partial class AuthJsonSerializerContext : ApiJsonSerializerContext;