using System.Text.Json.Serialization;

namespace FirebaseAuth.Requests;

public class SignupRequest
{
    public SignupRequest(
        string email,
        string password,
        bool returnSecureToken)
    {
        Email = email;
        Password = password;
        ReturnSecureToken = returnSecureToken;
    }

    [JsonPropertyName("email")]
    public string Email { get; set; }

    [JsonPropertyName("password")]
    public string Password { get; set; }

    [JsonPropertyName("returnSecureToken")]
    public bool ReturnSecureToken { get; set; }
}