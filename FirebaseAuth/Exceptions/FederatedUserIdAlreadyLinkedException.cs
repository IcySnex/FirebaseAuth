﻿namespace FirebaseAuth.Exceptions;

public class FederatedUserIdAlreadyLinkedException : AuthenticationException
{
    /// <summary>
    /// This credential is already associated with a different user account.
    /// </summary>
    public FederatedUserIdAlreadyLinkedException() : base("FEDERATED_USER_ID_ALREADY_LINKED", "This credential is already associated with a different user account.") { }
}