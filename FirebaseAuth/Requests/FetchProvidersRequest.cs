using FirebaseAuth.Internal.Json;
using FirebaseAuth.Types;
using System.Text.Json.Serialization;

namespace FirebaseAuth.Requests;

/// <summary>
/// Model to send a fetch providers by email request
/// </summary>
public class FetchProvidersRequest
{
    /// <summary>
    /// Creates a new FetchProvidersRequest
    /// </summary>
    /// <param name="continueUri">The URI to which the IDP redirects the user back</param>
    /// <param name="identifier">The identifier to fetch</param>
    /// <param name="oauthScopes">Scopes for the OAuth verification</param>
    /// <param name="provider">The respected OAuth provider</param>
    public FetchProvidersRequest(
        string continueUri,
        string? identifier = null,
        string[]? oauthScopes = null,
        Provider? provider = null)
    {
        ContinueUri = continueUri;
        Identifier = identifier;
        OauthScopes = oauthScopes;
        Provider = provider;
    }

    /// <summary>
    /// The URI to which the IDP redirects the user back
    /// </summary>
    [JsonPropertyName("continueUri")]
    public string ContinueUri { get; set; }

    /// <summary>
    /// The identifier to fetch
    /// </summary>
    [JsonPropertyName("identifier")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Identifier { get; set; }

    /// <summary>
    /// Scopes for the OAuth verification
    /// </summary>
    [JsonConverter(typeof(ArrayStringConverter))]
    [JsonPropertyName("oauthScopes")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string[]? OauthScopes { get; set; }

    /// <summary>
    /// The respected OAuth provider
    /// (Undefined & EmailAndPassword will result in an exception)
    /// </summary>
    [JsonConverter(typeof(ProviderJsonConverter))]
    [JsonPropertyName("providerId")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public Provider? Provider { get; set; }

}