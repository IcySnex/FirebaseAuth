using System.Text.Json.Serialization;

namespace FirebaseAuth.Requests;

/// <summary>
/// Model to send a new user data request
/// </summary>
public class UserDataRequest
{
    /// <summary>
    /// Creates a new UserDataRequest
    /// </summary>
    /// <param name="idToken">The Id token of the requested user</param>
    public UserDataRequest(
        string idToken)
    {
        IdToken = idToken;
    }

    /// <summary>
    /// The email for the new user
    /// </summary>
    [JsonPropertyName("idToken")]
    public string IdToken { get; set; }
}