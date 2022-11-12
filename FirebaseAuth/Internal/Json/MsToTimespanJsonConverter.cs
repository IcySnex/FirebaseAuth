using System.Text.Json.Serialization;
using System.Text.Json;

namespace FirebaseAuth.Internal.Json;

public class MsToDateTimeJsonConverter : JsonConverter<DateTime>
{
    public override DateTime Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options) =>
        DateTimeOffset.FromUnixTimeMilliseconds(reader.GetInt64()).ToLocalTime().DateTime;

    public override void Write(
        Utf8JsonWriter writer,
        DateTime dateTime,
        JsonSerializerOptions options) =>
        writer.WriteStringValue(new DateTimeOffset(dateTime).ToUnixTimeMilliseconds().ToString());
}

public class MsStringToDateTimeJsonConverter : JsonConverter<DateTime>
{
    public override DateTime Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options) =>
        DateTimeOffset.FromUnixTimeMilliseconds(reader.GetString() is string s ? long.Parse(s) : 0).ToLocalTime().DateTime;

    public override void Write(
        Utf8JsonWriter writer,
        DateTime dateTime,
        JsonSerializerOptions options) =>
        writer.WriteStringValue(new DateTimeOffset(dateTime).ToUnixTimeMilliseconds().ToString());
}

public class SStringToDateTimeJsonConverter : JsonConverter<DateTime>
{
    public override DateTime Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options) =>
        DateTimeOffset.FromUnixTimeSeconds(reader.GetString() is string s ? long.Parse(s) : 0).ToLocalTime().DateTime;

    public override void Write(
        Utf8JsonWriter writer,
        DateTime dateTime,
        JsonSerializerOptions options) =>
        writer.WriteStringValue(new DateTimeOffset(dateTime).ToUnixTimeSeconds().ToString());
}