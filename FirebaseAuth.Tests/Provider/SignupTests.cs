using FirebaseAuth.Authentication;
using FirebaseAuth.Configuration;
using FirebaseAuth.Exceptions;
using FirebaseAuth.Requests;
using FirebaseAuth.Requests.Interfaces;

namespace FirebaseAuth.Tests.Provider;

public class SignUpTests
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
    public void Anonymously_Success()
    {
        // Mock request
        ISignUpRequest request = ISignUpRequest.WithAnonymously(TestData.ReturnSecureToken);

        // Run Test: Expected behaviour: Run without exception
        Assert.DoesNotThrowAsync(async () =>
        {
            await provider.SignUpAsync(request);
        });
    }

    [Test]
    [Ignore("Disable Anonymous login inside 'Firebase Authentication Console Panel: Sign in methods' to test")]
    public void Anonymously_Failure_AdminOnlyOperation()
    {
        // Mock request
        ISignUpRequest request = ISignUpRequest.WithAnonymously(TestData.ReturnSecureToken);

        // Run Test: Expected behaviour: Throw exception
        Assert.ThrowsAsync(typeof(AdminOnlyOperationException), async () =>
        {
            await provider.SignUpAsync(request);
        });
    }


    [Test]
    public void EmailPassword_Success()
    {
        // Mock request
        ISignUpRequest request = ISignUpRequest.WithEmailPassword(TestData.RandomEmail, TestData.Password, TestData.ReturnSecureToken);

        // Run Test: Expected behaviour: Run without exception
        Assert.DoesNotThrowAsync(async () =>
        {
            await provider.SignUpAsync(request);
        });
    }

    [Test]
    public void EmailPassword_Failure_EmailExists()
    {
        // Mock request
        ISignUpRequest request = ISignUpRequest.WithEmailPassword(TestData.Email, TestData.Password, TestData.ReturnSecureToken);

        // Run Test: Expected behaviour: Run first time without exception, but throw exception on second try
        Assert.ThrowsAsync(typeof(EmailExistsException), async () =>
        {
            await provider.SignUpAsync(request);
            await provider.SignUpAsync(request);
        });
    }

    [Test]
    [Ignore("Disable Email & Password login inside 'Firebase Authentication Console Panel: Sign in methods' to test")]
    public void EmailPassword_Failure_OperationNotAllowed()
    {
        // Mock request
        ISignUpRequest request = ISignUpRequest.WithEmailPassword(TestData.RandomEmail, TestData.Password, TestData.ReturnSecureToken);

        // Run Test: Expected behaviour: Throw exception
        Assert.ThrowsAsync(typeof(OperationNotAllowedException), async () =>
        {
            await provider.SignUpAsync(request);
        });
    }

    [Test]
    [Ignore("Spams the Firebase API: Only run this test on-demand!")]
    public void EmailPassword_Failure_TooManyAttempts()
    {
        // Run Test: Expected behaviour: Throw exception
        Assert.ThrowsAsync(typeof(TooManyAttemptsException), async () =>
        {
            for (int i = 0; i < TestData.MaxRetries; i++)
            {
                //Mock request
                ISignUpRequest request = ISignUpRequest.WithEmailPassword(TestData.RandomEmail, TestData.Password, TestData.ReturnSecureToken);

                await provider.SignUpAsync(request);
            }
        });
    }

    [Test]
    public void EmailPassword_Failure_InvalidEmail()
    {
        // Mock request
        ISignUpRequest request = ISignUpRequest.WithEmailPassword("this is not a valid email", TestData.Password, TestData.ReturnSecureToken);

        // Run Test: Expected behaviour: Run first time without exception, but throw exception on second try
        Assert.ThrowsAsync(typeof(InvalidEmailException), async () =>
        {
            await provider.SignUpAsync(request);
        });
    }

    [Test]
    public void EmailPassword_Failure_MissingEmail()
    {
        // Mock request
        ISignUpRequest request = ISignUpRequest.WithEmailPassword("", TestData.Password, TestData.ReturnSecureToken);

        // Run Test: Expected behaviour: Throw exception
        Assert.ThrowsAsync(typeof(MissingEmailException), async () =>
        {
            await provider.SignUpAsync(request);
        });
    }

    [Test]
    public void EmailPassword_Failure_MissingPassword()
    {
        // Mock request
        ISignUpRequest request = ISignUpRequest.WithEmailPassword(TestData.RandomEmail, "", TestData.ReturnSecureToken);

        // Run Test: Expected behaviour: Throw exception
        Assert.ThrowsAsync(typeof(MissingPasswordException), async () =>
        {
            await provider.SignUpAsync(request);
        });
    }
}