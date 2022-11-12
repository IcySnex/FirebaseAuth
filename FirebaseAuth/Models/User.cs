using FirebaseAuth.Internal.Json;
using System.Text.Json.Serialization;

namespace FirebaseAuth.Models;

/// <summary>
/// Model representing an Authentication user
/// </summary>
public class User
{
    /// <summary>
    /// Creates a new User
    /// (Should only be used by AuthenticationProvider)
    /// </summary>
    /// <param name="localId">The local ID of this user</param>
    /// <param name="email">The email of this user</param>
    /// <param name="isEmailVerified">A boolean wether the email of this user is verified</param>
    /// <param name="displayName">The display name of this user</param>
    /// <param name="providerInfos">A list containg all provider infos of this user</param>
    /// <param name="photoUrl">The photo url of this user</param>
    /// <param name="passwordHash">The password hash of this user</param>
    /// <param name="passwordUpdatedAt">The date and time when the password of this user last got updated</param>
    /// <param name="validSince">The timespan since when this user is valid</param>
    /// <param name="isDisabled">A boolean wether this user is disabled</param>
    /// <param name="lastLoginAt">The date and time when this user last logged in</param>
    /// <param name="createdAt">The date and time when this user was created</param>
    /// <param name="isCustomAuth">A boolean whether the account is authenticated by the developer</param>
    /// <param name="lastRefreshAt">The date and time when this user was last refreshed</param>
    [JsonConstructor]
    public User(string localId,
        string email,
        bool isEmailVerified,
        string displayName,
        ProviderInfo[] providerInfos,
        string photoUrl,
        string passwordHash,
        DateTime passwordUpdatedAt,
        DateTime validSince,
        bool isDisabled,
        DateTime lastLoginAt,
        DateTime createdAt,
        bool isCustomAuth,
        DateTime lastRefreshAt)
    {
        LocalId = localId;
        Email = email;
        IsEmailVerified = isEmailVerified;
        DisplayName = displayName;
        ProviderInfos = providerInfos;
        PhotoUrl = photoUrl;
        PasswordHash = passwordHash;
        PasswordUpdatedAt = passwordUpdatedAt;
        ValidSince = validSince;
        IsDisabled = isDisabled;
        LastLoginAt = lastLoginAt;
        CreatedAt = createdAt;
        IsCustomAuth = isCustomAuth;
        LastRefreshAt = lastRefreshAt;
    }


    /// <summary>
    /// The local ID of this user
    /// </summary>
    [JsonPropertyName("localId")]
    public string LocalId { get; }

    /// <summary>
    /// The email of this user
    /// </summary>
    [JsonPropertyName("email")]
    public string Email { get; }

    /// <summary>
    /// A boolean wether the email of this user is verified
    /// </summary>
    [JsonPropertyName("emailVerified")]
    public bool IsEmailVerified { get; }

    /// <summary>
    /// The display name of this user
    /// </summary>
    [JsonPropertyName("displayName")]
    public string DisplayName { get; }

    /// <summary>
    /// A list containg all provider infos of this user
    /// </summary>
    [JsonPropertyName("providerUserInfo")]
    public ProviderInfo[] ProviderInfos { get; }

    /// <summary>
    /// The photo url of this user
    /// </summary>
    [JsonPropertyName("photoUrl")]
    public string PhotoUrl { get; }

    /// <summary>
    /// The password hash of this user
    /// </summary>
    [Obsolete("Showing passwords in your application may be dangerous! (Even if its hashed)")]
    [JsonPropertyName("passwordHash")]
    public string PasswordHash { get; }

    /// <summary>
    /// The date and time when the password of this user last got updated
    /// </summary>
    [JsonConverter(typeof(MsToDateTimeJsonConverter))]
    [JsonPropertyName("passwordUpdatedAt")]
    public DateTime PasswordUpdatedAt { get; }

    /// <summary>
    /// The timespan since when this user is valid
    /// </summary>
    [JsonConverter(typeof(MsStringToDateTimeJsonConverter))]
    [JsonPropertyName("validSince")]
    public DateTime ValidSince { get; }

    /// <summary>
    /// A boolean wether this user is disabled
    /// </summary>
    [JsonPropertyName("disabled")]
    public bool IsDisabled { get; }

    /// <summary>
    /// The date and time when this user last logged in
    /// </summary>
    [JsonConverter(typeof(MsStringToDateTimeJsonConverter))]
    [JsonPropertyName("lastLoginAt")]
    public DateTime LastLoginAt { get; }

    /// <summary>
    /// The date and time when this user was created
    /// </summary>
    [JsonConverter(typeof(MsStringToDateTimeJsonConverter))]
    [JsonPropertyName("createdAt")]
    public DateTime CreatedAt { get; }

    /// <summary>
    /// A boolean whether the account is authenticated by the developer
    /// </summary>
    [JsonPropertyName("customAuth")]
    public bool IsCustomAuth { get; }

    /// <summary>
    /// The date and time when this user was last refreshed
    /// </summary>
    [JsonPropertyName("lastRefreshAt")]
    public DateTime LastRefreshAt { get; }
}