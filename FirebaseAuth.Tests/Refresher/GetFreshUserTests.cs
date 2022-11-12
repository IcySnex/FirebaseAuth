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
        // Get old recieved date and time
        DateTime oldUpdatedAt = refresher.User?.Recieved ?? DateTime.Now;

        // Wait 3s and get new recieved date and time
        await Task.Delay(3000);
        User user = await refresher.GetFreshUserAsync(TimeSpan.FromMilliseconds(3000));
        DateTime newUpdatedAt = user.Recieved;

        // Run Test: Expected behaviour: new UpdatedAt is later than old UpdatedAt
        Assert.That(newUpdatedAt, Is.GreaterThan(oldUpdatedAt));
    }

    [Test]
    public async Task Success_DontRefresh()
    {
        // Get old recieved date and time
        DateTime oldUpdatedAt = refresher.User?.Recieved ?? DateTime.Now;

        // Get new recieved date and time
        User user = await refresher.GetFreshUserAsync(TimeSpan.FromMilliseconds(3000));
        DateTime newUpdatedAt = user.Recieved;

        // Run Test: Expected behaviour: old UpdatedAt does equal new UpdatedAt
        Assert.That(oldUpdatedAt, Is.EqualTo(newUpdatedAt));
    }
}