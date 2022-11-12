using FirebaseAuth.Models;
using FirebaseAuth.Requests;

namespace FirebaseAuth.Interfaces;

/// <summary>
/// Provider for all Firebase Authentication actions
/// </summary>
public interface IAuthenticationProvider
{
    /// <summary>
    /// Requests all data of an user
    /// </summary>
    /// <param name="request">The UserDataRequest to request</param>
    /// <param name="cancellationToken">The token to cancel this action</param>
    /// <returns>An user model which represents all the users data</returns>
    Task<User> GetUserDataAsync(
        UserDataRequest request,
        CancellationToken cancellationToken = default);
}