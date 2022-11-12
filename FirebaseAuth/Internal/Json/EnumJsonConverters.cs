using System.Text.Json.Serialization;
using System.Text.Json;
using FirebaseAuth.Types;

namespace FirebaseAuth.Internal.Json;

public class ProviderJsonConverter : JsonConverter<Provider>
{
    public override Provider Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options) =>
        reader.GetString() is string s ? EnumHelper.ToEnum<Provider>(s) : Provider.Undefined;


    public override void Write(
        Utf8JsonWriter writer,
        Provider provider,
        JsonSerializerOptions options) =>
        writer.WriteStringValue(EnumHelper.ToString(provider, "undefined"));
}

public class GrantTypeJsonConverter : JsonConverter<GrantType>
{
    public override GrantType Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options) =>
        reader.GetString() is string s ? EnumHelper.ToEnum<GrantType>(s) : GrantType.RefreshToken;


    public override void Write(
        Utf8JsonWriter writer,
        GrantType grandType,
        JsonSerializerOptions options) =>
        writer.WriteStringValue(EnumHelper.ToString(grandType, "refresh_token"));
}