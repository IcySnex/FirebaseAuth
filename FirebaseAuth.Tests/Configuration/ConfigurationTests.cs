using FirebaseAuth.Configuration;

namespace FirebaseAuth.Tests.Configuration;

public class ConfigurationTests
{
    [Test]
    public void Create_NewConfiguration_Success()
    {
        // Create new Configuration
        AuthenticationConfig firebaseCongiguration = new(TestData.ApiKey, TestData.Timeout);

        // Run Test: Expected behaviour: Given API key and timeout does equal to configuration values
        Assert.That(firebaseCongiguration.ApiKey, Is.EqualTo(TestData.ApiKey));
        Assert.That(firebaseCongiguration.Timeout, Is.EqualTo(TestData.Timeout));
    }

    [Test]
    public void Create_NewConfigurationFromString_Success()
    {
        // Create new Configuration
        AuthenticationConfig firebaseCongiguration = TestData.ApiKey.AsAuthenticationConfig();

        // Run Test: Expected behaviour: Given API key and timeout does equal to configuration values
        Assert.That(firebaseCongiguration.ApiKey, Is.EqualTo(TestData.ApiKey));
        Assert.That(firebaseCongiguration.Timeout, Is.EqualTo(TestData.Timeout));
    }
}