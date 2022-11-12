namespace FirebaseAuth.Configuration;

public static class AuthenticationExtentions
{
    /// <summary>
    /// Creates a new new configuration
    /// </summary>
    /// <param name="apiKey">The Firebase Web API key</param>
    /// <param name="timeout">The time span in which a request times out</param>
    /// <returns>A new AuthenticationConfig</returns>
    public static AuthenticationConfig AsAuthenticationConfig(
        this string apiKey,
        TimeSpan? timeout = null) =>
        new(apiKey, timeout);
}