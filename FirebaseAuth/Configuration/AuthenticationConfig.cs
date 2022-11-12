namespace FirebaseAuth.Configuration;

/// <summary>
/// configuration for the Firebase Authentication API
/// </summary>
public class AuthenticationConfig
{
    /// <summary>
    /// Creates a new new AuthenticationConfig
    /// </summary>
    /// <param name="apiKey">The Firebase Web API key</param>
    /// <param name="timeout">The time span in which a request times out</param>
    public AuthenticationConfig(
        string apiKey,
        TimeSpan? timeout = null)
    {
        ApiKey = apiKey;
        Timeout = timeout;
    }


    /// <summary>
    /// The Firebase Web API key
    /// </summary>
    public string ApiKey { get; }

    /// <summary>
    /// The time span in which a request times out
    /// </summary>
    public TimeSpan? Timeout { get; }
}