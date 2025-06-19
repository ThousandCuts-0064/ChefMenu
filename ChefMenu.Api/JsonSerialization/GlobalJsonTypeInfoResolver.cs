using System.Text.Json.Serialization.Metadata;
using ChefMenu.Api.Endpoints.Auth;
using ChefMenu.Api.JsonSerialization.JsonSerializerContexts;

namespace ChefMenu.Api.JsonSerialization;

public static class GlobalJsonTypeInfoResolver
{
    public static IJsonTypeInfoResolver Instance { get; } = JsonTypeInfoResolver.Combine(
        HttpResultJsonSerializerContext.Default,
        EnumJsonSerializerContext.Default,
        ValueObjectJsonSerializerContext.Default,
        AuthJsonSerializerContext.Default);
}