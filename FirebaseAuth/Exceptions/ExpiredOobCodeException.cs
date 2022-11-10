﻿namespace FirebaseAuth.Exceptions;

public class ExpiredOobCodeException : AuthenticationException
{
    /// <summary>
    /// The action code has expired.
    /// </summary>
    public ExpiredOobCodeException() : base("EXPIRED_OOB_CODE", "The action code has expired.") { }
}