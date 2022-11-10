﻿namespace FirebaseAuth.Exceptions;

public class InvalidAccessTokenException : AuthenticationException
{
    /// <summary>
    /// Third-party Auth Providers: PostBody does not contain or contains invalid Access Token string obtained from Auth Provider.
    /// </summary>
    public InvalidAccessTokenException() : base("invalid access_token, error code 43.", "Third-party Auth Providers: PostBody does not contain or contains invalid Access Token string obtained from Auth Provider.") { }
}