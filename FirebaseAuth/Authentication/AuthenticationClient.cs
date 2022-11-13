using FirebaseAuth.Configuration;
using FirebaseAuth.Exceptions;
using FirebaseAuth.Authentication.Interfaces;
using FirebaseAuth.Internal;
using FirebaseAuth.Models;
using FirebaseAuth.Requests;
using FirebaseAuth.Requests.Interfaces;
using FirebaseAuth.Responses;
using FirebaseAuth.Types;

namespace FirebaseAuth.Authentication;

/// <summary>
/// Client for all high level Firebase Authentication actions
/// </summary>
public class AuthenticationClient : IAuthenticationClient
{
    readonly RequestHelper requestHelper;

    /// <summary>
    /// Creates a new AuthenticationClient
    /// </summary>
    /// <param name="authenticationConfig">The configuration the AuthenticationClient should be created with</param>
    public AuthenticationClient(
        AuthenticationConfig config)
    {
        requestHelper = new(config);
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
    /// <returns>A refreshed AuthenticationResponse</returns>
    public Task<AuthenticationResponse> RefreshAuthenticationAsync(
        RefreshAuthenticationRequest request,
        CancellationToken cancellationToken = default)
    {
        // Send HTTP request and return authentication
        return requestHelper.PostBodyAndParseAsync<AuthenticationResponse>(Endpoints.SecureTokenGoogleApisCom, request, null, cancellationToken);
    }

    /// <summary>
    /// Creates a new refresher and optionally request all data of an user
    /// </summary>
    /// <param name="authentication">The AuthenticationResponse used for the refresher</param>
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
    /// <returns>A new IAuthenticationRefresher which handles all authentication refreshes</returns>
    async Task<IAuthenticationRefresher> GetAuthenticationRefresherAsync(
        AuthenticationResponse authentication,
        bool includeUser = true,
        CancellationToken cancellationToken = default)
    {
        // Return new refresher without user
        if (!includeUser)
            return new AuthenticationRefresher(this, authentication);

        // Get user and return new refresher
        UserDataRequest userRequest = new(authentication.IdToken);
        User user = await GetUserDataAsync(userRequest, cancellationToken);
        return new AuthenticationRefresher(this, authentication, user);
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
    /// Signs in an user
    /// </summary>
    /// <param name="request">The SignInRequest to send</param>
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
    /// <returns>A new IAuthenticationRefresher which handles all authentication refreshes</returns>
    public async Task<IAuthenticationRefresher> SignInAsync(
        ISignInRequest request,
        CancellationToken cancellationToken = default)
    {
        // Determine endpoint based on ISignInRequest and send HTTP request
        AuthenticationResponse response = await requestHelper.PostBodyAndParseAsync<AuthenticationResponse>(
            request.Type switch
            {
                SignInType.CustomToken => Endpoints.VerifyCustomToken,
                SignInType.EmailPassword => Endpoints.VerifyPassword,
                _ => throw new AuthenticationException("MISSING_SIGNIN_TYPE", "No SignIn type was given.")
            },request, null, cancellationToken);

        // Return refresher
        return await GetAuthenticationRefresherAsync(response, true, cancellationToken);
    }


    /// <summary>
    /// Signs up a new user
    /// </summary>
    /// <param name="request">The SignUpRequest to send</param>
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
    /// <returns>A new IAuthenticationRefresher which handles all authentication refreshes</returns>
    public async Task<IAuthenticationRefresher> SignUpAsync(
        ISignUpRequest request,
        CancellationToken cancellationToken = default)
    {
        // Send HTTP request
        AuthenticationResponse response = await requestHelper.PostBodyAndParseAsync<AuthenticationResponse>(Endpoints.SignupNewUser, request, null, cancellationToken);

        // Return refresher
        return await GetAuthenticationRefresherAsync(response, true, cancellationToken);
    }
}