using FirebaseAuth.Internal.Json;
using FirebaseAuth.Types;
using System.Text.Json.Serialization;

namespace FirebaseAuth.Requests;

/// <summary>
/// Model to send a new exchange a refresh token for an Id token request
/// </summary>
public class RefreshAuthenticationRequest
{
    /// <summary>
    /// Creates a new RefreshAuthenticationRequest
    /// </summary>
    /// <param name="refreshToken">The refresh token</param>
    /// <param name="grantType">The Firebase token grand type</param>
    public RefreshAuthenticationRequest(
        string refreshToken,
        GrantType grantType = GrantType.RefreshToken)
    {
        RefreshToken = refreshToken;
        GrantType = grantType;
    }

    /// <summary>
    /// The refresh token
    /// </summary>
    [JsonPropertyName("refresh_token")]
    public string RefreshToken { get; set; }

    /// <summary>
    /// The Firebase token grand type
    /// </summary>
    [JsonPropertyName("grant_type")]
    [JsonConverter(typeof(GrantTypeJsonConverter))]
    public GrantType GrantType { get; set; }
}