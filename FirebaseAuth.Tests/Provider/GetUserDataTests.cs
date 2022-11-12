using FirebaseAuth.Authentication;
using FirebaseAuth.Configuration;
using FirebaseAuth.Requests;

namespace FirebaseAuth.Tests.Provider;

public class GetUserDataTests
{
    readonly AuthenticationConfig config;
    readonly AuthenticationProvider provider;

    public GetUserDataTests()
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

}