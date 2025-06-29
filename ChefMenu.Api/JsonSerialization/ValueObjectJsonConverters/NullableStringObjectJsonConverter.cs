using System.Text.Json;
using System.Text.Json.Serialization;
using ChefMenu.Domain.Features.Core.ValueObjects;

namespace ChefMenu.Api.JsonSerialization.ValueObjectJsonConverters;

public class NullableStringObjectJsonConverter<TSelf> : JsonConverter<TSelf?>
    where TSelf : struct, IValueObject<TSelf, string>
{
    public override bool HandleNull => true;

    public override TSelf? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var value = reader.GetString();

        if (value is null)
        {
            return null;
        }

        if (!TSelf.TryCreate(value, out var result))
        {
            return null;
        }

        return result;
    }

    public override void Write(Utf8JsonWriter writer, TSelf? value, JsonSerializerOptions options)
    {
        if (value is null)
        {
            writer.WriteNullValue();

            return;
        }

        writer.WriteStringValue(value.Value);
    }
}