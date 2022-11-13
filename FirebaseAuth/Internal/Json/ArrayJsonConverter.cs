using System.Text.Json.Serialization;
using System.Text.Json;
using FirebaseAuth.Types;
using System.Reflection.PortableExecutable;

namespace FirebaseAuth.Internal.Json;

public class ArrayStringConverter : JsonConverter<string[]>
{
    public override string[] Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options)
    {
        if (reader.TokenType != JsonTokenType.StartArray)
            throw new JsonException();

        List<string> list = new();

        reader.Read();

        while (reader.TokenType != JsonTokenType.EndArray)
        {
            list.Add(JsonSerializer.Deserialize<string>(ref reader, options)!);
            reader.Read();
        }

        return list.ToArray();
    }

    public override void Write(
        Utf8JsonWriter writer,
        string[] array,
        JsonSerializerOptions options)
    {
        writer.WriteStringValue(string.Join(',', array));
    }
}

public class ProviderArrayJsonConverter : JsonConverter<Provider[]>
{
    public override Provider[] Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options)
    {
        if (reader.TokenType != JsonTokenType.StartArray)
            throw new JsonException();

        List<Provider> list = new();

        reader.Read();

        while (reader.TokenType != JsonTokenType.EndArray)
        {
            list.Add(EnumHelper.ToEnum<Provider>(JsonSerializer.Deserialize<string>(ref reader, options)!));
            reader.Read();
        }

        return list.ToArray();
    }

    public override void Write(
        Utf8JsonWriter writer,
        Provider[] providerArray,
        JsonSerializerOptions options)
    {
        foreach (Provider provider in providerArray)
            writer.WriteStringValue(EnumHelper.ToString(provider, "undefined"));
    }
}