using FirebaseAuth.Configuration;
using FirebaseAuth.Exceptions;
using FirebaseAuth.Interfaces;
using FirebaseAuth.Internal;
using FirebaseAuth.Models;
using FirebaseAuth.Requests;
using FirebaseAuth.Responses;

namespace FirebaseAuth.Authentication;

/// <summary>
/// Provider for all Firebase Authentication actions
/// </summary>
public class AuthenticationProvider : IAuthenticationProvider
{
    readonly RequestHelper requestHelper;

    /// <summary>
    /// Creates a new AuthenticationProvider
    /// </summary>
    /// <param name="authenticationConfig">The configuration the AuthenticationProvider should be created with</param>
    public AuthenticationProvider(
        AuthenticationConfig authenticationConfig)
    {
        requestHelper = new(authenticationConfig);
    }


    /// <summary>
    /// Requests all data of an user
    /// </summary>
    /// <param name="request">The UserDataRequest to send</param>
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
    /// <returns>An user model which represents all the users data</returns>
    public async Task<User> GetUserDataAsync(
        UserDataRequest request,
        CancellationToken cancellationToken = default)
    {
        // Send HTTP request and return first user
        UserDataResponse response = await requestHelper.PostBodyAndParseAsync<UserDataResponse>(Endpoints.GetAccountInfo, request, null, cancellationToken);
        return response.Users[0];
    }


    /// <summary>
    /// Refreshes the authentication by exchanging a refresh token for an Id token
    /// </summary>
    /// <param name="request">The RefreshAuthenticationRequest to send</param>
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
    /// <returns>An user model which represents all the users data</returns>
    public Task<AuthenticationResponse> RefreshAuthenticationAsync(
        RefreshAuthenticationRequest request,
        CancellationToken cancellationToken = default)
    {
        // Send HTTP request and return authentication
        return requestHelper.PostBodyAndParseAsync<AuthenticationResponse>(Endpoints.SecureTokenGoogleApisCom, request, null, cancellationToken);
    }


    public async Task<IAuthenticationRefresher> SignUpAsync(
        SignUpRequest request,
        CancellationToken cancellationToken = default)
    {
        // Send HTTP request
        AuthenticationResponse response = await requestHelper.PostBodyAndParseAsync<AuthenticationResponse>(Endpoints.SignupNewUser, request, null, cancellationToken);

        // Get user and return refresher
        User user = await GetUserDataAsync(new(response.IdToken), cancellationToken);
        return new AuthenticationRefresher(this, response, user);
    }
}