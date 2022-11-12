using System.Text.Json.Serialization;

namespace FirebaseAuth.Requests;

/// <summary>
/// Model to send a new SingUp request
/// </summary>
public class SignUpRequest
{
    /// <summary>
    /// Creates a new SingUpRequest
    /// </summary>
    /// <param name="email">The email for the new user</param>
    /// <param name="password">The password for the new user</param>
    /// <param name="returnSecureToken">Boolean wether to return a SecureToken</param>
    /// <param name="tenantId">The tenant ID for the new user</param>
    public SignUpRequest(
        string email,
        string password,
        bool returnSecureToken = true,
        string? tenantId = null)
    {
        Email = email;
        Password = password;
        ReturnSecureToken = returnSecureToken;
        TenantId = tenantId;
    }

    /// <summary>
    /// The email for the new user
    /// </summary>
    [JsonPropertyName("email")]
    public string Email { get; set; }

    /// <summary>
    /// The password for the new user
    /// </summary>
    [JsonPropertyName("password")]
    public string Password { get; set; }

    /// <summary>
    /// Boolean wether to return a SecureToken
    /// </summary>
    [JsonPropertyName("returnSecureToken")]
    public bool ReturnSecureToken { get; set; }

    /// <summary>
    /// The tenant ID for the new user
    /// </summary>
    [JsonPropertyName("tenantId")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? TenantId { get; set; }
}