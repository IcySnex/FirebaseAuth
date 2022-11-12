using System.Text.Json.Serialization;

namespace FirebaseAuth.Requests;

/// <summary>
/// Model to send a new SignIn with CustomToken request
/// </summary>
public class SignInCustomTokenRequest
{
    /// <summary>
    /// Creates a new SignInCustomTokenRequest
    /// </summary>
    /// <param name="token">The token for the user</param>
    /// <param name="returnSecureToken">Boolean wether to return a SecureToken</param>
    public SignInCustomTokenRequest(
        string token,
        bool returnSecureToken = true)
    {
        Token = token;
        ReturnSecureToken = returnSecureToken;
    }

    /// <summary>
    /// The token for the user
    /// </summary>
    [JsonPropertyName("token")]
    public string Token { get; set; }

    /// <summary>
    /// Boolean wether to return a SecureToken
    /// </summary>
    [JsonPropertyName("returnSecureToken")]
    public bool ReturnSecureToken { get; set; }
}