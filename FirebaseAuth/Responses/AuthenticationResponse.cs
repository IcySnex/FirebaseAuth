using FirebaseAuth.Internal.Json;
using System.Text.Json.Serialization;

namespace FirebaseAuth.Responses;

/// <summary>
/// Model to recieve a Authentication response 
/// </summary>
public class AuthenticationResponse
{
    /// <summary>
    /// Creates a new AuthenticationResponse
    /// </summary>
    /// <param name="idToken">The new accounts ID token</param>
    /// <param name="refreshToken">The current secure RefreshToken</param>
    /// <param name="expiresIn">The expiration timespan for the RefreshToken</param>
    [JsonConstructor]
    public AuthenticationResponse(
        string idToken,
        string refreshToken,
        TimeSpan expiresIn)
    {
        IdToken = idToken;
        RefreshToken = refreshToken;
        ExpiresIn = expiresIn;
    }

    /// <summary>
    /// The new accounts ID token
    /// </summary>
    [JsonPropertyName("idToken")]
    public string IdToken { get; }

    /// <summary>
    /// The current secure RefreshToken
    /// </summary>
    [JsonPropertyName("refreshToken")]
    public string RefreshToken { get; }

    /// <summary>
    /// The expiration time in seconds for the RefreshToken
    /// </summary>
    [JsonConverter(typeof(SecondsJsonConverter))]
    [JsonPropertyName("expiresIn")]
    public TimeSpan ExpiresIn { get; }

    /// <summary>
    /// The date and time when this response was recieved
    /// </summary>
    public DateTime Recieved { get; } = DateTime.Now;

    /// <summary>
    /// A boolean wether the secure RefreshToken is expired
    /// </summary>
    public bool IsExpired => DateTime.Now > Recieved.Add(ExpiresIn);
}