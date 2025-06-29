using System.Text.Json.Serialization;
using ChefMenu.Domain.Enums;

namespace ChefMenu.Api.JsonSerialization.JsonSerializerContexts;

[JsonSerializable(typeof(UserRole))]
[JsonSerializable(typeof(CategoryType))]
internal sealed partial class EnumJsonSerializerContext : ApiJsonSerializerContext;