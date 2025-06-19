using System.Text.Json;
using System.Text.Json.Serialization;
using ChefMenu.Domain.Features.Core.ValueObjects;

namespace ChefMenu.Api.JsonSerialization.ValueObjectJsonConverters;

public class ValueObjectJsonConverter<TSelf, TValue> : JsonConverter<TSelf?>
    where TSelf : struct, IValueObject<TSelf, TValue>
    where TValue : IUtf8SpanParsable<TValue>, IUtf8SpanFormattable
{
    public override bool HandleNull => true;

    public override TSelf? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        int length = reader.HasValueSequence
            ? (int)reader.ValueSequence.Length
            : reader.ValueSpan.Length;

        var buffer = length <= 128
            ? stackalloc byte[length]
            : new byte[length];

        var count = reader.CopyString(buffer);

        if (!TValue.TryParse(buffer[..count], null, out var value))
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

        Span<byte> buffer = stackalloc byte[128];

        value.Value.Value.TryFormat(buffer, out var bytesWritten, default, null);

        writer.WriteStringValue(buffer[..bytesWritten]);
    }
}