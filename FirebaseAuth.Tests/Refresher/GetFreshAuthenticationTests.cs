using FirebaseAuth.Configuration;
using FirebaseAuth.Authentication.Interfaces;
using FirebaseAuth.Responses;
using FirebaseAuth.Requests.Interfaces;

namespace FirebaseAuth.Tests.Refresher;

public class GetFreshAuthenticationTests
{
    AuthenticationConfig config;
    IAuthenticationClient client;

    IAuthenticationRefresher refresher;

    [OneTimeSetUp]
    public async Task SetupAsync()
    {
        // Mock config/client
        config = new(TestData.ApiKey, TestData.Timeout);
        client = IAuthenticationClient.New(config);

        // Mock signup
        ISignUpRequest request = ISignUpRequest.WithEmailPassword(TestData.RandomEmail, TestData.Password, TestData.ReturnSecureToken);
        refresher = await client.SignUpAsync(request);

    }


    [Test]
    [Ignore("Takes too long: The default expiration time is 1 hour!")]
    public void Success_Refresh()
    {
        // Get old authentication
        AuthenticationResponse oldAuthentication = refresher.Authentication;

        // Run Test: Expected behaviour: Run without exception
        Assert.DoesNotThrowAsync(async () =>
        {
            // Wait úntil authentication is expired and get new authentication
            await Task.Delay(refresher.Authentication.ExpiresIn);
            AuthenticationResponse newAuthentication = await refresher.GetFreshAuthentcationAsync();

            // Run Test: Expected behaviour: new refresh token does not equal old refresh token
            Assert.That(newAuthentication.RefreshToken, Is.Not.EqualTo(oldAuthentication.RefreshToken));
        });
    }

    [Test]
    public void Success_DontRefresh()
    {
        // Get old authentication
        AuthenticationResponse oldAuthentication = refresher.Authentication;

        // Run Test: Expected behaviour: Run without exception
        Assert.DoesNotThrowAsync(async () =>
        {
            // Get new authentication
            AuthenticationResponse newAuthentication = await refresher.GetFreshAuthentcationAsync();

            // Run Test: Expected behaviour: new refresh token equals old refresh token
            Assert.That(newAuthentication.RefreshToken, Is.EqualTo(oldAuthentication.RefreshToken));
        });
    }
}