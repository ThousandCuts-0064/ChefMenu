using System.Text.Json.Serialization;
using ChefMenu.Domain.Features.Users.ValueObjects;

namespace ChefMenu.Api.JsonSerialization.JsonSerializerContexts;

[JsonSerializable(typeof(UserId))]
[JsonSerializable(typeof(Username))]
[JsonSerializable(typeof(Password))]
[JsonSerializable(typeof(PasswordHash))]
internal partial class ValueObjectJsonSerializerContext : ApiJsonSerializerContext;