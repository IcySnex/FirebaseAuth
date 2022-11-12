namespace FirebaseAuth.Internal;

/// <summary>
/// A collection of all Firebase Authentication endpoints
/// </summary>
internal static class Endpoints
{
    /// <summary>
    /// https://identitytoolkit.googleapis.com/v1/accounts:signInWithCustomToken
    /// </summary>
    public static string VerifyCustomToken = "https://identitytoolkit.googleapis.com/v1/accounts:signInWithCustomToken";

    /// <summary>
    /// https://securetoken.googleapis.com/v1/token
    /// </summary>
    public static string SecureTokenGoogleApisCom = "https://securetoken.googleapis.com/v1/token";

    /// <summary>
    /// https://identitytoolkit.googleapis.com/v1/accounts:signUp
    /// </summary>
    public static string SignupNewUser = "https://identitytoolkit.googleapis.com/v1/accounts:signUp";

    /// <summary>
    /// https://identitytoolkit.googleapis.com/v1/accounts:signInWithPassword
    /// </summary>
    public static string VerifyPassword = "https://identitytoolkit.googleapis.com/v1/accounts:signInWithPassword";

    /// <summary>
    /// https://identitytoolkit.googleapis.com/v1/accounts:signInWithIdp
    /// </summary>
    public static string VerifyAssertion = "https://identitytoolkit.googleapis.com/v1/accounts:signInWithIdp";

    /// <summary>
    /// https://identitytoolkit.googleapis.com/v1/accounts:createAuthUri
    /// </summary>
    public static string CreateAuthUri = "https://identitytoolkit.googleapis.com/v1/accounts:createAuthUri";

    /// <summary>
    /// https://identitytoolkit.googleapis.com/v1/accounts:sendOobCode
    /// </summary>
    public static string GetOobConfirmationCode = "https://identitytoolkit.googleapis.com/v1/accounts:sendOobCode";

    /// <summary>
    /// https://identitytoolkit.googleapis.com/v1/accounts:resetPassword
    /// </summary>
    public static string ResetPassword = "https://identitytoolkit.googleapis.com/v1/accounts:resetPassword";

    /// <summary>
    /// https://identitytoolkit.googleapis.com/v1/accounts:update
    /// </summary>
    public static string SetAccountInfo = "https://identitytoolkit.googleapis.com/v1/accounts:update";

    /// <summary>
    /// https://identitytoolkit.googleapis.com/v1/accounts:lookup
    /// </summary>
    public static string GetAccountInfo = "https://identitytoolkit.googleapis.com/v1/accounts:lookup";
}