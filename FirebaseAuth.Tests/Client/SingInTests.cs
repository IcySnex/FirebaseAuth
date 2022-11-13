using FirebaseAuth.Authentication.Interfaces;
using FirebaseAuth.Configuration;
using FirebaseAuth.Exceptions;
using FirebaseAuth.Requests.Interfaces;

namespace FirebaseAuth.Tests.Client;

public class SingInTests
{
    AuthenticationConfig config;
    IAuthenticationClient provider;

    [OneTimeSetUp]
    public void Setup()
    {
        // Mock config/provider
        config = new(TestData.ApiKey, TestData.Timeout);
        provider = IAuthenticationClient.New(config);
    }


    [Test]
    public void CustomToken_Success()
    {
        // Mock request
        ISignInRequest request = ISignInRequest.WithCustomToken(TestData.CustomToken, TestData.ReturnSecureToken);

        // Run Test: Expected behaviour: Run without exception
        Assert.DoesNotThrowAsync(async () =>
        {
            await provider.SignInAsync(request);
        });
    }

    [Test]
    public void CustomToken_Failure_InvalidCustomToken()
    {
        // Mock request
        ISignInRequest request = ISignInRequest.WithCustomToken("this is not a valid token", TestData.ReturnSecureToken);

        // Run Test: Expected behaviour: Throw exception
        Assert.ThrowsAsync(typeof(InvalidCustomTokenException), async () =>
        {
            await provider.SignInAsync(request);
        });
    }


    [Test]
    public void EmailPassword_Success()
    {
        // Mock request
        ISignInRequest request = ISignInRequest.WithEmailPassword(TestData.Email, TestData.Password, TestData.ReturnSecureToken);

        // Run Test: Expected behaviour: Run without exception
        Assert.DoesNotThrowAsync(async () =>
        {
            await provider.SignInAsync(request);
        });
    }

    [Test]
    public void EmailPassword_Failure_InvalidEmail()
    {
        // Mock request
        ISignInRequest request = ISignInRequest.WithEmailPassword("this is not a valid email", TestData.Password, TestData.ReturnSecureToken);

        // Run Test: Expected behaviour: Throw exception
        Assert.ThrowsAsync(typeof(InvalidEmailException) ,async () =>
        {
            await provider.SignInAsync(request);
        });
    }

    [Test]
    public void EmailPassword_Failure_EmailNotFound()
    {
        // Mock request
        ISignInRequest request = ISignInRequest.WithEmailPassword(TestData.RandomEmail, TestData.Password, TestData.ReturnSecureToken);

        // Run Test: Expected behaviour: Throw exception
        Assert.ThrowsAsync(typeof(EmailNotFoundException) ,async () =>
        {
            await provider.SignInAsync(request);
        });
    }

    [Test]
    public void EmailPassword_Failure_InvalidPassword()
    {
        // Mock request
        ISignInRequest request = ISignInRequest.WithEmailPassword(TestData.Email, "this is not a valid password", TestData.ReturnSecureToken);

        // Run Test: Expected behaviour: Throw exception
        Assert.ThrowsAsync(typeof(InvalidPasswordException) ,async () =>
        {
            await provider.SignInAsync(request);
        });
    }
}