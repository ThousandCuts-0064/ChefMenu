using System.Text.Json;
using System.Text.Json.Serialization;

namespace ChefMenu.Api.JsonSerialization.JsonSerializerContexts;

[JsonSourceGenerationOptions(
    JsonSerializerDefaults.Web,
    UseStringEnumConverter = true,
    RespectRequiredConstructorParameters = true,
    RespectNullableAnnotations = true,
    ReadCommentHandling = JsonCommentHandling.Allow,
    PropertyNameCaseInsensitive = true,
    PreferredObjectCreationHandling = JsonObjectCreationHandling.Populate,
    NumberHandling = JsonNumberHandling.AllowReadingFromString,
    GenerationMode = JsonSourceGenerationMode.Serialization,
    DictionaryKeyPolicy = JsonKnownNamingPolicy.CamelCase,
    DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
    AllowTrailingCommas = true)]
internal abstract class ApiJsonSerializerContext : JsonSerializerContext
{
    protected ApiJsonSerializerContext(JsonSerializerOptions? options) : base(options) { }
}