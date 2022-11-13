using FirebaseAuth.Configuration;

namespace FirebaseAuth.Tests.Configuration;

public class ConfigurationTests
{
    [Test]
    public void Create_NewConfiguration_Success()
    {
        // Create new Configuration
        AuthenticationConfig config = new(TestData.ApiKey, TestData.Timeout);

        // Run Test: Expected behaviour: Given API key and timeout does equal to configuration values
        Assert.That(config.ApiKey, Is.EqualTo(TestData.ApiKey));
        Assert.That(config.Timeout, Is.EqualTo(TestData.Timeout));
    }

    [Test]
    public void Create_NewConfigurationFromString_Success()
    {
        // Create new Configuration
        AuthenticationConfig config = TestData.ApiKey.AsAuthenticationConfig();

        // Run Test: Expected behaviour: Given API key and timeout does equal to configuration values
        Assert.That(config.ApiKey, Is.EqualTo(TestData.ApiKey));
        Assert.That(config.Timeout, Is.EqualTo(TestData.Timeout));
    }
}