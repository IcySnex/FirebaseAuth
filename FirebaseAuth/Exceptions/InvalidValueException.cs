﻿namespace FirebaseAuth.Exceptions;

public class InvalidValueException : AuthenticationException
{
    /// <summary>
    /// Some value in the request was an invalid type.
    /// </summary>
    public InvalidValueException() : base("INVALID_VALUE", "Some value in the request was an invalid type.") { }
}