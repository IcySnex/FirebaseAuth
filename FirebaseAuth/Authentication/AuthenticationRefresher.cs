using FirebaseAuth.EventArgs;
using FirebaseAuth.Interfaces;
using FirebaseAuth.Responses;

namespace FirebaseAuth.Authentication;

/// <summary>
/// Manager to handle all Authentication refreshes
/// </summary>
public class AuthenticationRefresher : IAuthenticationRefresher
{
    readonly IAuthenticationProvider provider;
    AuthenticationResponse response;

    /// <summary>
    /// Creates a new AuthenticationRefresher
    /// </summary>
    /// <param name="provider">The provider which created this AuthenticationRefresher</param>
    /// <param name="response">The corresponding response</param>
    public AuthenticationRefresher(
        IAuthenticationProvider provider,
        AuthenticationResponse response)
    {
        this.provider = provider;
        this.response = response;
    }


    /// <summary>
    /// Fires when the current secure RefreshToken refreshed
    /// </summary>
    public event EventHandler<RefreshTokenRefreshEventArgs>? RefreshTokenRefreshed;


    /// <summary>
    /// Checks if the current secure RefreshToken is expired and if so sends a new RefreshRequest
    /// </summary>
    /// <returns>An always refreshed AuthenticationResponse</returns>
    public async Task<AuthenticationResponse> GetFreshAuthentcationAsync()
    {
        if (!response.IsExpired)
            return response;

        AuthenticationResponse freshResponse = response;//await provider.RefreshAuthenticationAsync(response);
        RefreshTokenRefreshed?.Invoke(this, new(response, freshResponse));
        response = freshResponse;

        return response;
    }
}