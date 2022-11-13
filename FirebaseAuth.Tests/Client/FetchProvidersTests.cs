using FirebaseAuth.Authentication.Interfaces;
using FirebaseAuth.Configuration;
using FirebaseAuth.Exceptions;
using FirebaseAuth.Requests;

namespace FirebaseAuth.Tests.Client;

public class FetchProvidersTests
{
    AuthenticationConfig config;
    IAuthenticationClient client;

    [OneTimeSetUp]
    public void Setup()
    {
        // Mock config/client
        config = new(TestData.ApiKey, TestData.Timeout);
        client = IAuthenticationClient.New(config);
    }


    [Test]
    public void Success()
    {
        // Mock request
        FetchProvidersRequest request = new("https://localhost", TestData.Email);

        // Run Test: Expected behaviour: Run without exception
        Assert.DoesNotThrowAsync(async () =>
        {
            await client.FetchProvidersAsync(request);
        });
    }

    [Test]
    public void Failure_InvalidIdentifier()
    {
        // Mock request
        FetchProvidersRequest request = new("https://localhost", "this is not a valid identifier");

        // Run Test: Expected behaviour: Throw exception
        Assert.ThrowsAsync(typeof(InvalidIdentifierException), async () =>
        {
            await client.FetchProvidersAsync(request);
        });
    }
}