using FirebaseAuth.Requests.Interfaces;
using FirebaseAuth.Types;
using System.Text.Json.Serialization;

namespace FirebaseAuth.Requests;

/// <summary>
/// Model to send a new SingUp with anonymously request
/// </summary>
public class SignUpAnonymouslyRequest : ISignUpRequest
{
    /// <summary>
    /// Creates a new SignUpAnonymouslyRequest
    /// </summary>
    /// <param name="returnSecureToken">Boolean wether to return a SecureToken</param>
    public SignUpAnonymouslyRequest(
        bool returnSecureToken = true)
    {
        ReturnSecureToken = returnSecureToken;
    }

    /// <summary>
    /// Boolean wether to return a SecureToken
    /// </summary>
    [JsonPropertyName("returnSecureToken")]
    public bool ReturnSecureToken { get; set; }


    /// <summary>
    /// The type of this SignUp request
    /// </summary>
    [JsonIgnore]
    public SignUpType Type { get; } = SignUpType.EmailPassword;
}