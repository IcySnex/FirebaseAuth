using FirebaseAuth.EventArgs;
using FirebaseAuth.Responses;

namespace FirebaseAuth.Interfaces;

/// <summary>
/// Manager to handle all Authentication refreshes
/// </summary>
public interface IAuthenticationRefresher
{
    /// <summary>
    /// Fires when the current secure RefreshToken refreshed
    /// </summary>
    event EventHandler<RefreshTokenRefreshEventArgs>? RefreshTokenRefreshed;


    /// <summary>
    /// Checks if the current secure RefreshToken is expired and if so sends a new RefreshRequest
    /// </summary>
    /// <returns>An always refreshed AuthenticationResponse</returns>
    Task<AuthenticationResponse> GetFreshAuthentcationAsync();

}