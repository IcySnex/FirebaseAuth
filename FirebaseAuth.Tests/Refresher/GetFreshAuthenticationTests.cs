using FirebaseAuth.Authentication;
using FirebaseAuth.Configuration;
using FirebaseAuth.Interfaces;
using FirebaseAuth.Requests;
using FirebaseAuth.Responses;

namespace FirebaseAuth.Tests.Refresher;

public class GetFreshAuthenticationTests
{
    AuthenticationConfig config;
    AuthenticationProvider provider;

    IAuthenticationRefresher refresher;

    [OneTimeSetUp]
    public async Task SetupAsync()
    {
        // Mock config/provider
        config = new(TestData.ApiKey, TestData.Timeout);
        provider = new(config);

        // Mock signup
        SignUpRequest request = new(TestData.RandomEmail, TestData.Password, TestData.ReturnSecureToken);
        refresher = await provider.SignUpAsync(request);

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