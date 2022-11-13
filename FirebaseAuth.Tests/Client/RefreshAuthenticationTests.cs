using FirebaseAuth.Configuration;
using FirebaseAuth.Exceptions;
using FirebaseAuth.Authentication.Interfaces;
using FirebaseAuth.Requests;
using FirebaseAuth.Responses;

namespace FirebaseAuth.Tests.Client;

public class RefreshAuthenticationTests
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
        SignUpEmailPasswordRequest request = new(TestData.RandomEmail, TestData.Password, TestData.ReturnSecureToken);
        refresher = await client.SignUpAsync(request);
    }


    [Test]
    public void Success()
    {
        // Mock request
        RefreshAuthenticationRequest request = new(refresher.Authentication.RefreshToken);

        // Run Test: Expected behaviour: Run without exception
        Assert.DoesNotThrowAsync(async () =>
        {
            AuthenticationResponse authentication = await client.RefreshAuthenticationAsync(request);

            // Run Test: Expected behaviour: new refresh token does not equal to old refresh token
            Assert.That(authentication.RefreshToken, Is.Not.EqualTo(refresher.Authentication.RefreshToken));
        });
    }

    [Test]
    public void Failure_MissingRefreshToken()
    {
        // Mock request
        RefreshAuthenticationRequest request = new("");

        // Run Test: Expected behaviour: Throw exception
        Assert.ThrowsAsync(typeof(MissingRefreshTokenException), async () =>
        {
            AuthenticationResponse authentication = await client.RefreshAuthenticationAsync(request);
        });
    }

    [Test]
    public void Failure_InvalidRefreshToken()
    {
        // Mock request
        RefreshAuthenticationRequest request = new("this is an invalid refresh token");

        // Run Test: Expected behaviour: Throw exception
        Assert.ThrowsAsync(typeof(InvalidRefreshTokenException), async () =>
        {
            AuthenticationResponse authentication = await client.RefreshAuthenticationAsync(request);
        });
    }
}