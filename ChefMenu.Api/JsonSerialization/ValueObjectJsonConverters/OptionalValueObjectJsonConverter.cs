using System.Text.Json;
using System.Text.Json.Serialization;
using ChefMenu.Api.RequestValidations;
using ChefMenu.Domain.Features.Core.ValueObjects;

namespace ChefMenu.Api.JsonSerialization.ValueObjectJsonConverters;

public class OptionalValueObjectJsonConverter<TSelf, TValue> : JsonConverter<Optional<TSelf>>
    where TSelf : struct, IValueObject<TSelf, TValue>
    where TValue : IUtf8SpanParsable<TValue>, IUtf8SpanFormattable
{
    public override Optional<TSelf> Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.TokenType == JsonTokenType.Null)
        {
            return Optional.Valid<TSelf>(null);
        }

        int length = reader.HasValueSequence
            ? (int)reader.ValueSequence.Length
            : reader.ValueSpan.Length;

        Span<byte> buffer = stackalloc byte[length];

        var count = reader.CopyString(buffer);

        if (!TValue.TryParse(buffer[..count], null, out var value))
        {
            return Optional.Invalid<TSelf>();
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

        Span<byte> buffer = stackalloc byte[writer.BytesPending];

        if (!value.ValueObject.Value.Value.TryFormat(buffer, out var bytesWritten, default, null))
        {
            throw new InvalidOperationException($"Could not format {typeof(TSelf).Name}");
        }

        writer.WriteStringValue(buffer[..bytesWritten]);
    }
}