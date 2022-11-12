using FirebaseAuth.Models;

namespace FirebaseAuth.EventArgs;

/// <summary>
/// Event arguments for when an user gets refreshed
/// </summary>
public class UserRefreshEventArgs : System.EventArgs
{
    /// <summary>
    /// The old user before it got refreshed
    /// </summary>
    public User? OldUser { get; }

    /// <summary>
    /// The new user after it got refreshed
    /// </summary>
    public User? NewUser { get; }

    /// <summary>
    /// The date and time when it got refreshed
    /// </summary>
    public DateTime OccurredAt { get; } = DateTime.Now;

    /// <summary>
    /// Creates new UserRefreshEventArgs
    /// </summary>
    public UserRefreshEventArgs(
        User? oldUser,
        User? newUser)
    {
        OldUser = oldUser;
        NewUser = newUser;
    }
}