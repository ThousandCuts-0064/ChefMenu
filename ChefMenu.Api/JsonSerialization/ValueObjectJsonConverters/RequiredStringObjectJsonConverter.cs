using System.Text.Json;
using System.Text.Json.Serialization;
using ChefMenu.Api.RequestValidations;
using ChefMenu.Domain.Features.Core.ValueObjects;

namespace ChefMenu.Api.JsonSerialization.ValueObjectJsonConverters;

public class RequiredStringObjectJsonConverter<TSelf> : JsonConverter<Required<TSelf>>
    where TSelf : struct, IValueObject<TSelf, string>
{
    public override Required<TSelf> Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var value = reader.GetString();

        if (value is null)
        {
            return Required.Invalid<TSelf>();
        }

        if (!TSelf.TryCreate(value, out var result))
        {
            return Required.Invalid<TSelf>();
        }

        return Required.Valid(result);
    }

    public override void Write(Utf8JsonWriter writer, Required<TSelf> value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(value.ValueObject.Value);
    }
}