namespace FirebaseAuth.Internal;

/// <summary>
/// Message handler which adds the API key to every request
/// </summary>
internal class ApiKeyHttpMessageHandler : DelegatingHandler
{
    readonly string key;

    /// <summary>
    /// Creates a new ApiKeyHtppMessageHandler
    /// </summary>
    /// <param name="key">The api key which should be added</param>
    public ApiKeyHttpMessageHandler(
        string key)
    {
        this.key = key;

        InnerHandler = new HttpClientHandler();
    }


    protected override Task<HttpResponseMessage> SendAsync(
        HttpRequestMessage request,
        CancellationToken cancellationToken)
    {
        request.RequestUri = new($"{request.RequestUri}?key={key}");

        return base.SendAsync(request, cancellationToken);
    }
}