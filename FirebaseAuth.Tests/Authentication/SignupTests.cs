using FirebaseAuth.Authentication;
using FirebaseAuth.Configuration;
using FirebaseAuth.Exceptions;
using FirebaseAuth.Requests;

namespace FirebaseAuth.Tests.Authentication;

public class SignupTests
{
    readonly AuthenticationConfig config;
    readonly AuthenticationProvider provider;

    public SignupTests()
    {
        // Mock config/provider
        config = new(TestData.ApiKey, TestData.Timeout);
        provider = new(config);
    }


    [Test]
    public void SignUpAsync_Success()
    {
        // Mock request
        SignupRequest request = new(TestData.RandomEmail, TestData.Password, TestData.ReturnSecureToken);

        // Run Test: Expected behaviour: Run without exception
        Assert.DoesNotThrowAsync(async () =>
        {
            await provider.SignUpAsync(request);
        });
    }

    [Test]
    public void SignUpAsync_Failure_EmailExists()
    {
        // Mock request
        SignupRequest request = new(TestData.Email, TestData.Password, TestData.ReturnSecureToken);

        // Run Test: Expected behaviour: Run first time without exception, but throw exception on second try
        Assert.ThrowsAsync(typeof(EmailExistsException), async () =>
        {
            await provider.SignUpAsync(request);
            await provider.SignUpAsync(request);
        });
    }

    [Test] // DISABLE EMAIL&PASSWORD LOGIN INSIDE "FIREBASE AUTHENTICATION CONSOLE PANEL: SIGN IN METHODS" TO TEST
    [Ignore("Spams the firebase api: Only run this test on-demand!")]
    public void SignUpAsync_Failure_OperationNotAllowed()
    {
        // Mock request
        SignupRequest request = new(TestData.RandomEmail, TestData.Password, TestData.ReturnSecureToken);

        // Run Test: Expected behaviour: Throw exception
        Assert.ThrowsAsync(typeof(OperationNotAllowedException), async () =>
        {
            await provider.SignUpAsync(request);
        });
    }

    [Test]
    public void SignUpAsync_Failure_InvalidEmail()
    {
        // Mock request
        SignupRequest request = new("thisisnotanemail", TestData.Password, TestData.ReturnSecureToken);

        // Run Test: Expected behaviour: Run first time without exception, but throw exception on second try
        Assert.ThrowsAsync(typeof(InvalidEmailException), async () =>
        {
            await provider.SignUpAsync(request);
        });
    }

    [Test]
    public void SignUpAsync_Failure_MissingEmail()
    {
        // Mock request
        SignupRequest request = new("", TestData.Password, TestData.ReturnSecureToken);

        // Run Test: Expected behaviour: Run first time without exception, but throw exception on second try
        Assert.ThrowsAsync(typeof(MissingEmailException), async () =>
        {
            await provider.SignUpAsync(request);
        });
    }

    [Test]
    public void SignUpAsync_Failure_MissingPassword()
    {
        // Mock request
        SignupRequest request = new(TestData.RandomEmail, "", TestData.ReturnSecureToken);

        // Run Test: Expected behaviour: Run first time without exception, but throw exception on second try
        Assert.ThrowsAsync(typeof(MissingPasswordException), async () =>
        {
            await provider.SignUpAsync(request);
        });
    }

}