using FirebaseAuth.Authentication;
using FirebaseAuth.Configuration;
using FirebaseAuth.Exceptions;
using FirebaseAuth.Requests;

namespace FirebaseAuth.Tests.Provider;

public class SingInTests
{
    AuthenticationConfig config;
    AuthenticationProvider provider;

    [OneTimeSetUp]
    public void Setup()
    {
        // Mock config/provider
        config = new(TestData.ApiKey, TestData.Timeout);
        provider = new(config);
    }


    [Test]
    public void Success()
    {
        // Mock request
        SignInCustomTokenRequest request = new(TestData.CustomToken, TestData.ReturnSecureToken);

        // Run Test: Expected behaviour: Run without exception
        Assert.DoesNotThrowAsync(async () =>
        {
            await provider.SignInAsync(request);
        });
    }

    [Test]
    public void Failure_InvalidCustomToken()
    {
        // Mock request
        SignInCustomTokenRequest request = new("this is not a valid token", TestData.ReturnSecureToken);

        // Run Test: Expected behaviour: Run without exception
        Assert.ThrowsAsync(typeof(InvalidCustomTokenException), async () =>
        {
            await provider.SignInAsync(request);
        });
    }
}