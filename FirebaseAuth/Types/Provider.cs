﻿using System.Runtime.Serialization;

namespace FirebaseAuth.Types;

/// <summary>
/// The provider type of the Authentication
/// </summary>
public enum Provider
{
    /// <summary>
    /// Could not get the Provider type
    /// </summary>
    [EnumMember(Value = "undefined")]
    Undefined,

    /// <summary>
    /// Authentication using email and password
    /// </summary>
    [EnumMember(Value = "password")]
    EmailAndPassword,

    /// <summary>
    /// Authentication using Facebook
    /// </summary>
    [EnumMember(Value = "facebook.com")]
    Faceook,

    /// <summary>
    /// Authentication using Google
    /// </summary>
    [EnumMember(Value = "google.com")]
    Google,

    /// <summary>
    /// Authentication using Apple
    /// </summary>
    [EnumMember(Value = "apple.com")]
    Apple,

    /// <summary>
    /// Authentication using Github
    /// </summary>
    [EnumMember(Value = "github.com")]
    Github,

    /// <summary>
    /// Authentication using Twitter
    /// </summary>
    [EnumMember(Value = "twitter.com")]
    Twitter
}