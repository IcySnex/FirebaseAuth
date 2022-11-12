using FirebaseAuth.Internal.Json;
using FirebaseAuth.Types;
using System.Text.Json.Serialization;

namespace FirebaseAuth.Models;

/// <summary>
/// Model representing a Authentication provider info
/// </summary>
public class ProviderInfo
{
    /// <summary>
    /// Creates a new ProviderInfo
    /// (Should only be used by AuthenticationProvider)
    /// </summary>
    /// <param name="provider">The type of this provider</param>
    /// <param name="displayName">The display name of this user</param>
    /// <param name="photoUrl">The photo url of this user</param>
    /// <param name="federatedId">The federated ID of this user</param>
    /// <param name="email">The email of this user</param>
    /// <param name="rawId">The raw ID of this user</param>
    /// <param name="screenName">The screen name of this user</param>
    public ProviderInfo(
        Provider provider,
        string displayName,
        string photoUrl,
        string federatedId,
        string email,
        string rawId,
        string screenName)
    {
        Provider = provider;
        DisplayName = displayName;
        PhotoUrl = photoUrl;
        FederatedId = federatedId;
        Email = email;
        RawId = rawId;
        ScreenName = screenName;
    }

    /// <summary>
    /// The type of this provider
    /// </summary>
    [JsonConverter(typeof(ProviderJsonConverter))]
    [JsonPropertyName("providerId")]
    public Provider Provider { get; }

    /// <summary>
    /// The display name of this user
    /// </summary>
    [JsonPropertyName("displayName")]
    public string DisplayName { get; }

    /// <summary>
    /// The photo url of this user
    /// </summary>
    [JsonPropertyName("photoUrl")]
    public string PhotoUrl { get; }

    /// <summary>
    /// The federated ID of this user
    /// </summary>
    [JsonPropertyName("federatedId")]
    public string FederatedId { get; }

    /// <summary>
    /// The email of this user
    /// </summary>
    [JsonPropertyName("email")]
    public string Email { get; }

    /// <summary>
    /// The raw ID of this user
    /// </summary>
    [JsonPropertyName("rawId")]
    public string RawId { get; }

    /// <summary>
    /// The screen name of this user
    /// </summary>
    [JsonPropertyName("screenName")]
    public string ScreenName { get; }
}