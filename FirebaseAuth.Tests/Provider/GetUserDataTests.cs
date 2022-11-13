using FirebaseAuth.Authentication;
using FirebaseAuth.Configuration;
using FirebaseAuth.Requests;

namespace FirebaseAuth.Tests.Provider;

public class GetUserDataTests
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
        UserDataRequest request = new(TestData.IdToken);

        // Run Test: Expected behaviour: Run without exception
        Assert.DoesNotThrowAsync(async () =>
        {
            await provider.GetUserDataAsync(request);
        });
    }

    [Test]
    public void Failure_InvalidIdToken()
    {
        UserDataRequest request = new("this is not a valid Id token");

        // Run Test: Expected behaviour: Run without exception
        Assert.DoesNotThrowAsync(async () =>
        {
            await provider.GetUserDataAsync(request);
        });
    }
}