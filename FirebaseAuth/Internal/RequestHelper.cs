using FirebaseAuth.Configuration;
using System.Net.Http;
using System.Text;

namespace FirebaseAuth.Internal;

internal class RequestHelper
{
    HttpClient httpClient;

    /// <summary>
    /// Creates a new RequestHelper which handles all HTTP requests
    /// </summary>
    /// <param name="authenticationConfig">The configuration for the HttpClient</param>
    public RequestHelper(
        AuthenticationConfig authenticationConfig)
    {
        ApiKeyHttpMessageHandler messageHandler = new(authenticationConfig.ApiKey);
        httpClient = new(messageHandler);

        if (authenticationConfig.Timeout.HasValue)
            httpClient.Timeout = authenticationConfig.Timeout.Value;

    }



    /// <summary>
    /// Sends a new POST request to the given uri with the serializes body
    /// </summary>
    /// <param name="uri">The uri the request should be made to</param>
    /// <param name="body">The body which should be serialized</param>
    /// <param name="headers">The optional headers for the request</param>
    /// <param name="cancellationToken">The cancellation token to cancel the action</param>
    /// <exception cref="NotSupportedException">May occurs when the json serialization fails</exception>
    /// <exception cref="FormatException">May occurs when adding a header fails</exception>
    /// <exception cref="ArgumentNullException">May occurs when sending the post request fails</exception>
    /// <exception cref="InvalidOperationException">May occurs when sending the post request fails</exception>
    /// <exception cref="HttpRequestException">May occurs when sending the post request fails</exception>
    /// <exception cref="TaskCanceledException">May occurs when sending the post request fails</exception>
    /// <returns>The HTTP response message</returns>
    public Task<HttpResponseMessage> PostBodyAsync(
        string uri,
        object body,
        (string key, string value)[]? headers = null,
        CancellationToken cancellationToken = default)
    {
        string serializedContent = JsonHelper.Serialize(body);

        var request = new HttpRequestMessage()
        {
            Method = HttpMethod.Post,
            RequestUri = new(uri),
            Content = new StringContent(serializedContent, Encoding.UTF8, "application/json"),
        };
        foreach ((string key, string value) in headers ?? Array.Empty<(string key, string value)>())
            request.Headers.Add(key, value);

        return httpClient.SendAsync(request, cancellationToken);
    }
}