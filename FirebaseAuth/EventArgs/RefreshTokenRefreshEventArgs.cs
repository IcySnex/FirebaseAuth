using FirebaseAuth.Responses;

namespace FirebaseAuth.EventArgs;

/// <summary>
/// Event arguments for when a secure RefreshToken gets refreshed
/// </summary>
public class RefreshTokenRefreshEventArgs : System.EventArgs
{
    /// <summary>
    /// The old AuthenticationResponse before it got refreshed
    /// </summary>
    public AuthenticationResponse OldResponse { get; }

    /// <summary>
    /// The new AuthenticationResponse after it got refreshed
    /// </summary>
    public AuthenticationResponse NewResponse { get; }

    /// <summary>
    /// The date and time when it got refreshed
    /// </summary>
    public DateTime OccurredAt { get; } = DateTime.Now;

    /// <summary>
    /// Creates new RefreshTokenRefreshEventArgs
    /// </summary>
    public RefreshTokenRefreshEventArgs(
        AuthenticationResponse oldResponse,
        AuthenticationResponse newResponse)
    {
        OldResponse = oldResponse;
        NewResponse = newResponse;
    }
}