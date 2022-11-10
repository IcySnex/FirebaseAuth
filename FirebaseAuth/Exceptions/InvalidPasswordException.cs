﻿namespace FirebaseAuth.Exceptions;

public class InvalidPasswordException : AuthenticationException
{
    /// <summary>
    /// The password is invalid or the user does not have a password.
    /// </summary>
    public InvalidPasswordException() : base("INVALID_PASSWORD", "The password is invalid or the user does not have a password.") { }
}