using FirebaseAuth.EventArgs;
using FirebaseAuth.Interfaces;
using FirebaseAuth.Models;
using FirebaseAuth.Responses;
using System.Diagnostics;

namespace FirebaseAuth.Authentication;

/// <summary>
/// Manager to handle all Authentication refreshes
/// </summary>
public class AuthenticationRefresher : IAuthenticationRefresher
{
    readonly IAuthenticationProvider provider;

    /// <summary>
    /// Creates a new AuthenticationRefresher
    /// </summary>
    /// <param name="provider">The provider which created this AuthenticationRefresher</param>
    /// <param name="response">The corresponding authenitcation</param>
    /// <param name="user">The corresponding user</param>
    public AuthenticationRefresher(
        IAuthenticationProvider provider,
        AuthenticationResponse response,
        User? user = null)
    {
        this.provider = provider;

        Authentication = response;
        User = user;
    }


    /// <summary>
    /// The corresponding authenitcation
    /// </summary>
    public AuthenticationResponse Authentication { get; private set; }

    /// <summary>
    /// Fires when the current secure AuthenticationResponse refreshed
    /// </summary>
    public event EventHandler<AuthenticationRefreshEventArgs>? AuthenticationRefreshed;

    /// <summary>
    /// Checks if the current authenitcation is expired and if so sends a new RefreshRequest
    /// </summary>
    /// <param name="cancellationToken">The token to cancel this action</param>
    /// <returns>An always refreshed AuthenticationResponse</returns>
    public async Task<AuthenticationResponse> GetFreshAuthentcationAsync(
        CancellationToken cancellationToken = default)
    {
        if (!Authentication.IsExpired)
            return Authentication;

        AuthenticationResponse freshResponse = Authentication;//await provider.RefreshAuthenticationAsync(response, cancellationToken);
        AuthenticationRefreshed?.Invoke(this, new(Authentication, freshResponse));
        Authentication = freshResponse;

        return Authentication;
    }


    /// <summary>
    /// The corresponding user
    /// </summary>
    public User? User { get; private set; }

    /// <summary>
    /// Fires when the current user refreshed
    /// </summary>
    public event EventHandler<UserRefreshEventArgs>? UserRefreshed;

    /// <summary>
    /// Checks if the current user is expired by the given time and if so sends a new UserDataRequest
    /// </summary>
    /// <param name="willExpireAfter">The given time to check if its expired. Null if it should always return a fresh user</param>
    /// <param name="cancellationToken">The token to cancel this action</param>
    /// <returns>An optioanlly refreshed User</returns>
    public async Task<User> GetFreshUserAsync(
        TimeSpan? willExpireAfter = null,
        CancellationToken cancellationToken = default)
    {
        Debug.WriteLine(User?.UpdatedAt.Add(willExpireAfter.Value) > DateTime.Now);
        if (willExpireAfter.HasValue && User?.UpdatedAt.Add(willExpireAfter.Value) > DateTime.Now)
            return User;

        User freshUser = await provider.GetUserDataAsync(new(Authentication.IdToken), cancellationToken);
        UserRefreshed?.Invoke(this, new(User, freshUser));
        User = freshUser;

        return User;
    }
}