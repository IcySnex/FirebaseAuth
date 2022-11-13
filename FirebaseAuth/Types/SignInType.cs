using FirebaseAuth.Requests;

namespace FirebaseAuth.Types;

/// <summary>
/// The type of a SignIn request
/// </summary>
public enum SignInType
{
    /// <summary>
    /// <see cref="SignInCustomTokenRequest"/>
    /// </summary>
    CustomToken,

    /// <summary>
    /// <see cref="SignInEmailPasswordRequest"/>
    /// </summary>
    EmailPassword
}