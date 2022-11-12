using FirebaseAuth.Authentication;
using FirebaseAuth.Configuration;
using FirebaseAuth.Exceptions;
using FirebaseAuth.Interfaces;
using FirebaseAuth.Models;
using FirebaseAuth.Requests;
using FirebaseAuth.Responses;
using System.Diagnostics;

namespace FirebaseAuth.Tests.Provider;

public class RefreshAuthenticationTests
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
    public void Success()
    {
        // Mock request
        RefreshAuthenticationRequest request = new(refresher.Authentication.RefreshToken);

        // Run Test: Expected behaviour: Run without exception
        Assert.DoesNotThrowAsync(async () =>
        {
            AuthenticationResponse authentication = await provider.RefreshAuthenticationAsync(request);

            // Run Test: Expected behaviour: new refresh token does not equal to old refresh token
            Assert.That(authentication.RefreshToken, Is.Not.EqualTo(refresher.Authentication.RefreshToken));
        });
    }
}