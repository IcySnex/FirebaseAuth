using FirebaseAuth.Requests.Interfaces;
using FirebaseAuth.Types;
using System.Text.Json.Serialization;

namespace FirebaseAuth.Requests;

/// <summary>
/// Model to send a new SignIn with EmailPassword request
/// </summary>
public class SignInEmailPasswordRequest : ISignInRequest
{
    /// <summary>
    /// Creates a new SignInEmailPasswordRequest
    /// </summary>
    /// <param name="email">The email of the user</param>
    /// <param name="password">The password of the user</param>
    /// <param name="returnSecureToken">Boolean wether to return a SecureToken</param>
    public SignInEmailPasswordRequest(
        string email,
        string password,
        bool returnSecureToken = true)
    {
        Email = email;
        Password = password;
        ReturnSecureToken = returnSecureToken;
    }

    /// <summary>
    /// The email of the user
    /// </summary>
    [JsonPropertyName("email")]
    public string Email { get; set; }

    /// <summary>
    /// The password of the user
    /// </summary>
    [JsonPropertyName("password")]
    public string Password { get; set; }

    /// <summary>
    /// Boolean wether to return a SecureToken
    /// </summary>
    [JsonPropertyName("returnSecureToken")]
    public bool ReturnSecureToken { get; set; }


    /// <summary>
    /// The type of this SignIn request
    /// </summary>
    [JsonIgnore]
    public SignInType Type { get; } = SignInType.EmailPassword;
}