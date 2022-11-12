// This file is excluded from pushing to git.
// Use Git GUI to open repo, Press Repository (top left), Click Git Bash
// Commands:    LOCK FILE:      git update-index --skip-worktree FirebaseAuth.Tests/TestData.cs
//              UNLOCK FILE:    git update-index --no-skip-worktree FirebaseAuth.Tests/TestData.cs

namespace FirebaseAuth.Tests;

internal class TestData
{
    /// <summary>
    /// The Firebase Web API key
    /// You can get find this here: https://console.firebase.google.com/u/0/project/<APPLICATION_NAME>/settings/general where <APPLICATION_NAME> represents your application name.
    /// </summary>
    public static readonly string ApiKey = "<FIREBASE WEB API KEY>";

    /// <summary>
    /// The time span in which a request times out
    /// </summary>
    public static readonly TimeSpan? Timeout = null;


    /// <summary>
    /// The default CustomToken for authentication
    /// </summary>
    public static readonly string CustomToken = "<CUSTOM TOKEN>";

    /// <summary>
    /// The default Id token for requests
    /// </summary>
    public static readonly string IdToken = "<ID TOKEN>";

    /// <summary>
    /// The default email address for authentication
    /// </summary>
    public static readonly string Email = "default@provider.com";

    /// <summary>
    /// The default email address with a random number for authentication
    /// </summary>
    public static string RandomEmail => new Random().Next(0, 5000) + Email;

    /// <summary>
    /// The default password for authentication
    /// </summary>
    public static readonly string Password = "password123!";

    /// <summary>
    /// The default return secure token value
    /// </summary>
    public static readonly bool ReturnSecureToken = true;

    /// <summary>
    /// The maxium tries to attempt to result in an TooManyAttempsException
    /// SET THIS TO THE MAX REGISTRATIONS PER HOUR FROM "FIREBASE AUTHENTICATION CONSOLE PANEL: SETTINGS: REGISTRATION QUOTA"
    /// </summary>
    public static readonly int MaxRetries = 10;
}