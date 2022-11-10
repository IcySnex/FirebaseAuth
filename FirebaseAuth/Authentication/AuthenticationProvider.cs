using FirebaseAuth.Configuration;
using FirebaseAuth.Exceptions;
using FirebaseAuth.Interfaces;
using FirebaseAuth.Internal;
using FirebaseAuth.Requests;

namespace FirebaseAuth.Authentication;

public class AuthenticationProvider : IAuthenticationProvider
{
    RequestHelper requestHelper;

    public AuthenticationProvider(
        AuthenticationConfig authenticationConfig)
    {
        requestHelper = new(authenticationConfig);
    }


    public async Task SignUpAsync(
        SignupRequest request,
        CancellationToken cancellationToken = default)
    {
        HttpResponseMessage response = await requestHelper.PostBodyAsync(Endpoints.SignupNewUser, request, cancellationToken: cancellationToken)
            .ConfigureAwait(false);

        string responseData = await response.Content.ReadAsStringAsync(cancellationToken)
            .ConfigureAwait(false);

        if (!response.IsSuccessStatusCode)
        {
            throw AuthenticationException.FromResponseData(responseData);
        }
    }
}