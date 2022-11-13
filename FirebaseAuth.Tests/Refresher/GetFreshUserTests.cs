using FirebaseAuth.Configuration;
using FirebaseAuth.Authentication.Interfaces;
using FirebaseAuth.Models;
using FirebaseAuth.Requests.Interfaces;

namespace FirebaseAuth.Tests.Refresher;

public class GetFreshUserTests
{
    AuthenticationConfig config;
    IAuthenticationClient client;

    IAuthenticationRefresher refresher;

    [OneTimeSetUp]
    public async Task SetupAsync()
    {
        // Mock config/client
        config = new(TestData.ApiKey, TestData.Timeout);
        client = IAuthenticationClient.New(config);

        // Mock signup
        ISignUpRequest request = ISignUpRequest.WithEmailPassword(TestData.RandomEmail, TestData.Password, TestData.ReturnSecureToken);
        refresher = await client.SignUpAsync(request);

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