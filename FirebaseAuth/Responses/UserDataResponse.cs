using FirebaseAuth.Models;
using System.Text.Json.Serialization;

namespace FirebaseAuth.Responses;

/// <summary>
/// Model to recieve a user data response 
/// </summary>
public class UserDataResponse
{
    /// <summary>
    /// Creates a new UserDataResponse
    /// (Should only be used by AuthenticationClient.GetUserDataAsync())
    /// </summary>
    /// <param name="users">An array of all users</param>
    [JsonConstructor]
    public UserDataResponse(
        User[] users)
    {
        Users = users;
    }

    /// <summary>
    /// An array of all users
    /// </summary>
    [JsonPropertyName("users")]
    public User[] Users { get; }
}