using FirebaseAuth.Authentication.Interfaces;
using FirebaseAuth.Configuration;
using FirebaseAuth.Requests;

namespace FirebaseAuth.Tests.Client;

public class GetUserDataTests
{
    AuthenticationConfig config;
    IAuthenticationClient client;

    [OneTimeSetUp]
    public void Setup()
    {
        // Mock config/provider
        config = new(TestData.ApiKey, TestData.Timeout);
        client = IAuthenticationClient.New(config);
    }


    [Test]
    public void Success()
    {
        UserDataRequest request = new(TestData.IdToken);

        // Run Test: Expected behaviour: Run without exception
        Assert.DoesNotThrowAsync(async () =>
        {
            await client.GetUserDataAsync(request);
        });
    }

    [Test]
    public void Failure_InvalidIdToken()
    {
        UserDataRequest request = new("this is not a valid Id token");

        // Run Test: Expected behaviour: Run without exception
        Assert.DoesNotThrowAsync(async () =>
        {
            await client.GetUserDataAsync(request);
        });
    }
}