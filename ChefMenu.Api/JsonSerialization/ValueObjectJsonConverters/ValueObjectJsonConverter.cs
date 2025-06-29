using System.Text.Json;
using System.Text.Json.Serialization;
using ChefMenu.Domain.Exceptions;
using ChefMenu.Domain.Features.Core.ValueObjects;

namespace ChefMenu.Api.JsonSerialization.ValueObjectJsonConverters;

public class ValueObjectJsonConverter<TSelf, TValue> : JsonConverter<TSelf>
    where TSelf : struct, IValueObject<TSelf, TValue>
    where TValue : IUtf8SpanParsable<TValue>, IUtf8SpanFormattable
{
    public override TSelf Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        int length = reader.HasValueSequence
            ? (int)reader.ValueSequence.Length
            : reader.ValueSpan.Length;

        Span<byte> buffer = stackalloc byte[length];

        var count = reader.CopyString(buffer);

        if (!TValue.TryParse(buffer[..count], null, out var value))
        {
            return ValueObjectException.Throw<TSelf>(reader.GetString());
        }

        return TSelf.Create(value);
    }

    public override void Write(Utf8JsonWriter writer, TSelf value, JsonSerializerOptions options)
    {
        Span<byte> buffer = stackalloc byte[writer.BytesPending];

        if (!value.Value.TryFormat(buffer, out var bytesWritten, default, null))
        {
            throw new InvalidOperationException($"Could not format {typeof(TSelf).Name}");
        }

        writer.WriteStringValue(buffer[..bytesWritten]);
    }
}