using System.Text.Json.Serialization;
using ChefMenu.Application.ValueObjects;
using ChefMenu.Domain.Features.Users.ValueObjects;

namespace ChefMenu.Api.JsonSerialization.JsonSerializerContexts;

[JsonSerializable(typeof(Username?))]
[JsonSerializable(typeof(PageSize?))]
[JsonSerializable(typeof(UserId))]
internal partial class ValueObjectJsonSerializerContext : ApiJsonSerializerContext;