﻿using FirebaseAuth.Internal.Json;
using FirebaseAuth.Responses;

namespace FirebaseAuth.Exceptions;

public class AuthenticationException : Exception
{
    /// <summary>
    /// Authentication error on server or client side
    /// </summary>
    public AuthenticationException(string message, string innerMessage) : base(message, new(innerMessage)) { }

    public string? ResponseData { get; private set; }


    /// <summary>
    /// Deserializes the given response data into a ErrorResponse model and checks for the representing exception
    /// </summary>
    /// <param name="responseData">The response data which should be deserialized</param>
    /// <exception cref="AuthenticationException">Throws the representing AuthenticationException</exception>
    /// <returns>The representing exception</returns>
    public static AuthenticationException FromResponseData(
        string responseData)
    {
        ErrorResponse response = JsonHelper.Deserialize<ErrorResponse>(responseData);
        string message = response.Error.Message;

        switch (message)
        {
            case "ADMIN_ONLY_OPERATION":
                return new AdminOnlyOperationException();

            case "API key not valid. Please pass a valid API key.":
                return new InvalidApiKeyException();

            case "A system error has occurred - missing or invalid postBody":
                return new SystemErrorException();

            case "CREDENTIAL_MISMATCH":
                return new CredentialMismatchException();

            case "CREDENTIAL_TOO_OLD_LOGIN_AGAIN":
                return new CredentialTooOldException();

            case "EMAIL_EXISTS":
                return new EmailExistsException();

            case "EMAIL_NOT_FOUND":
                return new EmailNotFoundException();

            case "EXPIRED_OOB_CODE":
                return new ExpiredOobCodeException();

            case "FEDERATED_USER_ID_ALREADY_LINKED":
                return new FederatedUserIdAlreadyLinkedException();

            case "invalid access_token, error code 43.":
                return new InvalidAccessTokenException();

            case "INVALID_CUSTOM_TOKEN":
                return new InvalidCustomTokenException();

            case "INVALID_EMAIL":
                return new InvalidEmailException();

            case "INVALID_GRANT_TYPE":
                return new InvalidGrandTypeException();

            case "INVALID_IDP_RESPONSE":
                return new InvalidIdpResponseException();

            case "INVALID_ID_TOKEN":
                return new InvalidIdTokenException();

            case "INVALID_OOB_CODE":
                return new InvalidOobCodeException();

            case "INVALID_PASSWORD":
                return new InvalidPasswordException();

            case "INVALID_REFRESH_TOKEN":
                return new InvalidRefreshTokenException();

            case "MISSING_EMAIL":
                return new MissingEmailException();

            case "MISSING_IDENTIFIER":
                return new MissingIdentifierException();
                
            case "MISSING_REFRESH_TOKEN":
                return new MissingRefreshTokenException();

            case "MISSING_REQ_TYPE":
                return new MissingReqTypeException();

            case "MISSING_REQUEST_URI":
                return new MissingRequestUriException();

            case "MISSING_PASSWORD":
                return new MissingPasswordException();

            case "RESET_PASSWORD_EXCEED_LIMIT":
                return new ResetPasswordExeedLimitException();
                
            case "OPERATION_NOT_ALLOWED":
                return new OperationNotAllowedException();

            case "TOKEN_EXPIRED":
                return new TokenExpiredException();

            case "USER_DISABLED":
                return new UserDisabledException();

            case "USER_NOT_FOUND":
                return new UserNotFoundException();

            default:
                if (message.StartsWith("WEAK_PASSWORD"))
                    return new WeakPasswordException();

                if (message.StartsWith("TOO_MANY_ATTEMPTS_TRY_LATER"))
                    return new TooManyAttemptsException();

                if (message.StartsWith("Invalid JSON payload received"))
                    return new InvalidJsonPayloadException();

                if (message.StartsWith("INVALID_PROVIDER_ID"))
                    return new InvalidProviderIdException();
                
                if (message.StartsWith("MISSING_OR_INVALID_NONCE"))
                    return new MissingOrInvalidNonceException();


                return new("UNDEFINDED", $"An unknown exception occurred while trying to communicate with the Firebase authentication server. ({message})") { ResponseData = responseData};
        }
    }
}