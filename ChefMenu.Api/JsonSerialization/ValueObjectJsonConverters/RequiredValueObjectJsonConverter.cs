using System.Text.Json;
using System.Text.Json.Serialization;
using ChefMenu.Api.RequestValidations;
using ChefMenu.Domain.Features.Core.ValueObjects;

namespace ChefMenu.Api.JsonSerialization.ValueObjectJsonConverters;

public class RequiredValueObjectJsonConverter<TSelf, TValue> : JsonConverter<Required<TSelf>>
    where TSelf : struct, IValueObject<TSelf, TValue>
    where TValue : IUtf8SpanParsable<TValue>, IUtf8SpanFormattable
{
    public override Required<TSelf> Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        int length = reader.HasValueSequence
            ? (int)reader.ValueSequence.Length
            : reader.ValueSpan.Length;

        Span<byte> buffer = stackalloc byte[length];

        var count = reader.CopyString(buffer);

        if (!TValue.TryParse(buffer[..count], null, out var value))
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
        Span<byte> buffer = stackalloc byte[writer.BytesPending];

        if (!value.ValueObject.Value.TryFormat(buffer, out var bytesWritten, default, null))
        {
            throw new InvalidOperationException($"Could not format {typeof(TSelf).Name}");
        }

        writer.WriteStringValue(buffer[..bytesWritten]);
    }
}