namespace FirebaseAuth.Internal;

internal static class Endpoints
{
    public static string VerifyCustomToken = "https://identitytoolkit.googleapis.com/v1/accounts:signInWithCustomToken";

    public static string SecureTokenGoogleApisCom = "https://securetoken.googleapis.com/v1/token";

    public static string SignupNewUser = "https://identitytoolkit.googleapis.com/v1/accounts:signUp";

    public static string VerifyPassword = "https://identitytoolkit.googleapis.com/v1/accounts:signInWithPassword";

    public static string VerifyAssertion = "https://identitytoolkit.googleapis.com/v1/accounts:signInWithIdp";

    public static string CreateAuthUri = "https://identitytoolkit.googleapis.com/v1/accounts:createAuthUri";

    public static string GetOobConfirmationCode = "https://identitytoolkit.googleapis.com/v1/accounts:sendOobCode";

    public static string ResetPassword = "https://identitytoolkit.googleapis.com/v1/accounts:resetPassword";

    public static string SetAccountInfo = "https://identitytoolkit.googleapis.com/v1/accounts:update";

    public static string GetAccountInfo = "https://identitytoolkit.googleapis.com/v1/accounts:lookup";
}