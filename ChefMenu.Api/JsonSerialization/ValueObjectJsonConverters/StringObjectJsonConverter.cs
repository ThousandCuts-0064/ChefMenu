using System.Text.Json;
using System.Text.Json.Serialization;
using ChefMenu.Domain.Exceptions;
using ChefMenu.Domain.Features.Core.ValueObjects;

namespace ChefMenu.Api.JsonSerialization.ValueObjectJsonConverters;

public class StringObjectJsonConverter<TSelf> : JsonConverter<TSelf>
    where TSelf : struct, IValueObject<TSelf, string>
{
    public override TSelf Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var value = reader.GetString();

        return TSelf.Create(value ?? ValueObjectException.Throw<TSelf>(null));
    }

    public override void Write(Utf8JsonWriter writer, TSelf value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(value.Value);
    }
}