using FirebaseAuth.Types;

namespace FirebaseAuth.Requests.Interfaces;

/// <summary>
/// Model to send a new SignUp request
/// </summary>
public interface ISignUpRequest
{
    /// <summary>
    /// The type of this SignUp request
    /// </summary>
    SignUpType Type { get; }


    /// <summary>
    /// Creates a new SignUpAnonymouslyRequest
    /// </summary>
    /// <param name="returnSecureToken">Boolean wether to return a SecureToken</param>
    public static ISignUpRequest WithAnonymously(
        bool returnSecureToken = true) =>
        new SignUpAnonymouslyRequest(returnSecureToken);

    /// <summary>
    /// Creates a new SignUpEmailPasswordRequest
    /// </summary>
    /// <param name="email">The email of the user</param>
    /// <param name="password">The password of the user</param>
    /// <param name="returnSecureToken">Boolean wether to return a SecureToken</param>
    public static ISignUpRequest WithEmailPassword(
        string email,
        string password,
        bool returnSecureToken = true,
        string? tenantId = null) =>
        new SignUpEmailPasswordRequest(email, password, returnSecureToken, tenantId);
}