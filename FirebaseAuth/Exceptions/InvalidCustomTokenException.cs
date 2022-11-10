﻿namespace FirebaseAuth.Exceptions;

public class InvalidCustomTokenException : AuthenticationException
{
    /// <summary>
    /// The custom token format is incorrect or the token is invalid for some reason (e.g. expired, invalid signature etc.)
    /// </summary>
    public InvalidCustomTokenException() : base("INVALID_CUSTOM_TOKEN", "The custom token format is incorrect or the token is invalid for some reason (e.g. expired, invalid signature etc.)") { }
}