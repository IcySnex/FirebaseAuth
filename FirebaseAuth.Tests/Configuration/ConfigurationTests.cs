using FirebaseAuth.Configuration;

namespace FirebaseAuth.Tests.Configuration;

public class ConfigurationTests
{
    [Test]
    public void Create_NewConfiguration_Success()
    {
        AuthenticationConfig firebaseCongiguration = new(TestData.ApiKey, TestData.Timeout);

        Assert.That(firebaseCongiguration.ApiKey, Is.EqualTo(TestData.ApiKey));
        Assert.That(firebaseCongiguration.Timeout, Is.EqualTo(TestData.Timeout));
    }

    [Test]
    public void Create_NewConfigurationFromString_Success()
    {
        AuthenticationConfig firebaseCongiguration = TestData.ApiKey.AsAuthenticationConfig();

        Assert.That(firebaseCongiguration.ApiKey, Is.EqualTo(TestData.ApiKey));
        Assert.That(firebaseCongiguration.Timeout, Is.EqualTo(TestData.Timeout));
    }
}