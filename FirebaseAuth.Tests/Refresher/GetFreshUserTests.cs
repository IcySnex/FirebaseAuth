using FirebaseAuth.Authentication;
using FirebaseAuth.Configuration;
using FirebaseAuth.Interfaces;
using FirebaseAuth.Models;
using FirebaseAuth.Requests;

namespace FirebaseAuth.Tests.Refresher;

public class GetFreshUserTests
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
    public async Task Success_Refresh()
    {
        // Get old UpdatedAt
        DateTime oldUpdatedAt = refresher.User?.UpdatedAt ?? DateTime.Now;

        // Wait 3s and get new UpdatedAt
        await Task.Delay(3000);
        User user = await refresher.GetFreshUserAsync(TimeSpan.FromMilliseconds(3000));
        DateTime newUpdatedAt = user.UpdatedAt;

        // Run Test: Expected behaviour: new UpdatedAt is later than old UpdatedAt
        Assert.That(newUpdatedAt, Is.GreaterThan(oldUpdatedAt));
    }

    [Test]
    public async Task Success_DontRefresh()
    {
        // Get old UpdatedAt
        DateTime oldUpdatedAt = refresher.User?.UpdatedAt ?? DateTime.Now;

        // Get new UpdatedAt
        User user = await refresher.GetFreshUserAsync(TimeSpan.FromMilliseconds(3000));
        DateTime newUpdatedAt = user.UpdatedAt;

        // Run Test: Expected behaviour: old UpdatedAt does equal new UpdatedAt
        Assert.That(oldUpdatedAt, Is.EqualTo(newUpdatedAt));
    }

}