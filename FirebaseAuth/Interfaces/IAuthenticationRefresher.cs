﻿using FirebaseAuth.EventArgs;
using FirebaseAuth.Models;
using FirebaseAuth.Responses;

namespace FirebaseAuth.Interfaces;

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
    /// <returns>An optioanlly refreshed User</returns>
    Task<User> GetFreshUserAsync(
        TimeSpan? willExpireAfter = null,
        CancellationToken cancellationToken = default);
}