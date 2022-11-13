using FirebaseAuth.Types;

namespace FirebaseAuth.Requests.Interfaces;

/// <summary>
/// Model to send a new SignIn request
/// </summary>
public interface ISignInRequest
{
    /// <summary>
    /// The type of this SignIn request
    /// </summary>
    SignInType Type { get; }


    /// <summary>
    /// Creates a new SignInCustomTokenRequest
    /// </summary>
    /// <param name="token">The token for the user</param>
    /// <param name="returnSecureToken">Boolean wether to return a SecureToken</param>
    public static ISignInRequest WithCustomToken(
        string token,
        bool returnSecureToken = true) =>
        new SignInCustomTokenRequest(token, returnSecureToken);

    /// <summary>
    /// Creates a new SignInEmailPasswordRequest
    /// </summary>
    /// <param name="email">The email of the user</param>
    /// <param name="password">The password of the user</param>
    /// <param name="returnSecureToken">Boolean wether to return a SecureToken</param>
    public static ISignInRequest WithEmailPassword(
        string email,
        string password,
        bool returnSecureToken = true) =>
        new SignInEmailPasswordRequest(email, password, returnSecureToken);
}