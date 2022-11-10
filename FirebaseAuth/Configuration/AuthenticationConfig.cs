namespace FirebaseAuth.Configuration;

public class AuthenticationConfig
{
    /// <summary>
    /// Creates a new new configuration for the Firebase Authentication API
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


    public string ApiKey { get; }
    public TimeSpan? Timeout { get; }
}