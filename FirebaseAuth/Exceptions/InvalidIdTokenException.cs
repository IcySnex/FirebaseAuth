﻿namespace FirebaseAuth.Exceptions;

public class InvalidIdTokenException : AuthenticationException
{
    /// <summary>
    /// The user's credential is no longer valid. The user must sign in again.
    /// </summary>
    public InvalidIdTokenException() : base("INVALID_ID_TOKEN", "The user's credential is no longer valid. The user must sign in again.") { }
}