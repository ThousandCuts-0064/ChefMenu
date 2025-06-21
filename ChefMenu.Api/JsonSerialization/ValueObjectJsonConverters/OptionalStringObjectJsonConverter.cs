using System.Text.Json;
using System.Text.Json.Serialization;
using ChefMenu.Api.RequestValidations;
using ChefMenu.Domain.Features.Core.ValueObjects;

namespace ChefMenu.Api.JsonSerialization.ValueObjectJsonConverters;

public class OptionalStringObjectJsonConverter<TSelf> : JsonConverter<Optional<TSelf>>
    where TSelf : struct, IValueObject<TSelf, string>
{
    public override Optional<TSelf> Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var value = reader.GetString();

        if (value is null)
        {
            return Optional.Valid<TSelf>(null);
        }

        if (!TSelf.TryCreate(value, out var result))
        {
            return Optional.Invalid<TSelf>();
        }

        return Optional.Valid(result);
    }

    public override void Write(Utf8JsonWriter writer, Optional<TSelf> value, JsonSerializerOptions options)
    {
        if (value.ValueObject is null)
        {
            writer.WriteNullValue();

            return;
        }

        writer.WriteStringValue(value.ValueObject.Value);
    }
}