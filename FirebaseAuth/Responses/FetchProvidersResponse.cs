using FirebaseAuth.Internal.Json;
using FirebaseAuth.Types;
using System.Text.Json.Serialization;

namespace FirebaseAuth.Responses;

/// <summary>
/// Model to recieve a fetch provider response 
/// </summary>
public class FetchProvidersResponse
{
    /// <summary>
    /// Creates a new FetchProvidersResponse
    /// (Should only be used by AuthenticationClient.FetchProvidersAsync())
    /// </summary>
    /// <param name="allProviders">The list of all providers</param>
    /// <param name="isRegistered">A boolean wether the email is registered</param>
    [JsonConstructor]
    public FetchProvidersResponse(
        Provider[] allProviders,
        bool isRegistered)
    {
        AllProviders = allProviders;
        IsRegistered = isRegistered;
    }

    /// <summary>
    /// The list of all providers
    /// </summary>
    [JsonConverter(typeof(ProviderArrayJsonConverter))]
    [JsonPropertyName("allProviders")]
    public Provider[] AllProviders { get; }

    /// <summary>
    /// A boolean wether the email is registered
    /// </summary>
    [JsonPropertyName("registered")]
    public bool IsRegistered { get; }
}