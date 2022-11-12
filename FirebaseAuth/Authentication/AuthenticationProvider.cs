using FirebaseAuth.Configuration;
using FirebaseAuth.Exceptions;
using FirebaseAuth.Interfaces;
using FirebaseAuth.Internal;
using FirebaseAuth.Models;
using FirebaseAuth.Requests;
using FirebaseAuth.Responses;
using System.Threading;

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


    /// <summary>
    /// Requests all data of an user
    /// </summary>
    /// <param name="request">The UserDataRequest to request</param>
    /// <param name="cancellationToken">The token to cancel this action</param>
    /// <returns>An user model which represents all the users data</returns>
    public async Task<User> GetUserDataAsync(
        UserDataRequest request,
        CancellationToken cancellationToken = default)
    {
        UserDataResponse response = await requestHelper.PostBodyAndParseAsync<UserDataResponse>(Endpoints.GetAccountInfo, request, null, cancellationToken);
        return response.Users[0];
    }
}