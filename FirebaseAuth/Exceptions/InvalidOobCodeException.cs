﻿namespace FirebaseAuth.Exceptions;

public class InvalidOobCodeException : AuthenticationException
{
    /// <summary>
    /// The action code is invalid. This can happen if the code is malformed, expired, or has already been used.
    /// </summary>
    public InvalidOobCodeException() : base("INVALID_OOB_CODE", "The action code is invalid. This can happen if the code is malformed, expired, or has already been used.") { }
}