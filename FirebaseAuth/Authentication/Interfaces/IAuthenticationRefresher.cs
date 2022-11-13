using FirebaseAuth.EventArgs;
using FirebaseAuth.Models;
using FirebaseAuth.Responses;

namespace FirebaseAuth.Authentication.Interfaces;

/// <summary>
/// Manager to handle all Authentication refreshes
/// </summary>
public interface IAuthenticationRefresher
{
    /// <summary>
    /// The corresponding authenitcation
    /// </summary>
    AuthenticationResponse Authentication { get; }

    /// <summary>
    /// Fires when the current secure AuthenticationResponse refreshed
    /// </summary>
    event EventHandler<AuthenticationRefreshEventArgs>? AuthenticationRefreshed;

    /// <summary>
    /// Checks if the current authenitcation is expired and if so sends a new RefreshRequest
    /// </summary>
    /// <param name="cancellationToken">The token to cancel this action</param>
    /// <exception cref="AuthenticationException">Occurs when the request failed on the Firebase Server</exception>
    /// <exception cref="ArgumentNullException">Occurs when json null is</exception>
    /// <exception cref="JsonException">Occurs when the JSON is invalid. -or- TValue is not compatible with the JSON. -or- There is remaining data in the string beyond a single JSON value.</exception>
    /// <exception cref="NotSupportedException">Occurs when there is no compatible System.Text.Json.Serialization.JsonConverter for TValue</exception>
    /// <exception cref="JsonObjectIsNullException">Occurs when deserialized object does not represent the Type T (is null)</exception>
    /// <exception cref="NotSupportedException">May occurs when the json serialization fails</exception>
    /// <exception cref="FormatException">May occurs when adding a header fails</exception>
    /// <exception cref="ArgumentNullException">May occurs when sending the post request fails</exception>
    /// <exception cref="InvalidOperationException">May occurs when sending the post request fails</exception>
    /// <exception cref="HttpRequestException">May occurs when sending the post request fails</exception>
    /// <exception cref="TaskCanceledException">May occurs when sending the post request fails</exception>
    /// <returns>An always refreshed AuthenticationResponse</returns>
    Task<AuthenticationResponse> GetFreshAuthentcationAsync(
        CancellationToken cancellationToken = default);


    /// <summary>
    /// The corresponding user
    /// </summary>
    User? User { get; }

    /// <summary>
    /// Fires when the current user refreshed
    /// </summary>
    event EventHandler<UserRefreshEventArgs>? UserRefreshed;

    /// <summary>
    /// Checks if the current user is expired by the given time and if so sends a new UserDataRequest
    /// </summary>
    /// <param name="willExpireAfter">The given time to check if its expired. Null if it should always return a fresh user</param>
    /// <param name="cancellationToken">The token to cancel this action</param>
    /// <exception cref="AuthenticationException">Occurs when the request failed on the Firebase Server</exception>
    /// <exception cref="ArgumentNullException">Occurs when json null is</exception>
    /// <exception cref="JsonException">Occurs when the JSON is invalid. -or- TValue is not compatible with the JSON. -or- There is remaining data in the string beyond a single JSON value.</exception>
    /// <exception cref="NotSupportedException">Occurs when there is no compatible System.Text.Json.Serialization.JsonConverter for TValue</exception>
    /// <exception cref="JsonObjectIsNullException">Occurs when deserialized object does not represent the Type T (is null)</exception>
    /// <exception cref="NotSupportedException">May occurs when the json serialization fails</exception>
    /// <exception cref="FormatException">May occurs when adding a header fails</exception>
    /// <exception cref="ArgumentNullException">May occurs when sending the post request fails</exception>
    /// <exception cref="InvalidOperationException">May occurs when sending the post request fails</exception>
    /// <exception cref="HttpRequestException">May occurs when sending the post request fails</exception>
    /// <exception cref="TaskCanceledException">May occurs when sending the post request fails</exception>
    /// <returns>An optioanlly refreshed User</returns>
    Task<User> GetFreshUserAsync(
        TimeSpan? willExpireAfter = null,
        CancellationToken cancellationToken = default);
}