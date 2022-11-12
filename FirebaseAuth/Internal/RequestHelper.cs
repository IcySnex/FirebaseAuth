using FirebaseAuth.Configuration;
using FirebaseAuth.Exceptions;
using FirebaseAuth.Internal.Json;
using FirebaseAuth.Responses;
using System.Text;
using System.Threading;

namespace FirebaseAuth.Internal;

/// <summary>
/// Helper which handles all HTTP requests
/// </summary>
internal class RequestHelper
{
    HttpClient httpClient;

    /// <summary>
    /// Creates a new RequestHelper
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
        // Serialize body
        string serializedContent = JsonHelper.Serialize(body);

        // Create HTTP request
        var request = new HttpRequestMessage()
        {
            Method = HttpMethod.Post,
            RequestUri = new(uri),
            Content = new StringContent(serializedContent, Encoding.UTF8, "application/json"),
        };
        foreach ((string key, string value) in headers ?? Array.Empty<(string key, string value)>())
            request.Headers.Add(key, value);

        // Send HTTP request
        return httpClient.SendAsync(request, cancellationToken);
    }

    /// <summary>
    /// Sends a new POST request to the given uri with the serializes body and parses it
    /// </summary>
    /// <typeparam name="T">The Type the response data should get parsed into</typeparam>
    /// <param name="uri">The uri the request should be made to</param>
    /// <param name="body">The body which should be serialized</param>
    /// <param name="headers">The optional headers for the request</param>
    /// <param name="cancellationToken">The cancellation token to cancel the action</param>
    /// <exception cref="AuthenticationException">Occurs when the request failed on the Firebase Server</exception>
    /// <exception cref="ArgumentNullException">Occurs when json null is</exception>
    /// <exception cref="JsonException">Occurs when the JSON is invalid. -or- TValue is not compatible with the JSON. -or- There is remaining data in the string beyond a single JSON value.</exception>
    /// <exception cref="NotSupportedException">Occurs when there is no compatible System.Text.Json.Serialization.JsonConverter for TValue</exception>
    /// <exception cref="JsonObjectIsNullException">Occurs when deserialized object does not represent the Type T (is null)</exception>
    /// <exception cref="NotSupportedException">May occurs when the json serialization fails</exception>
    /// <exception cref="FormatException">May occurs when adding a header fails</exception>
    /// <exception cref="ArgumentNullException">May occurs when sending the post request fails</exception>
    /// <exception cref="InvalidOperationException">May occurs when sending the post request fails</exception>
    /// <exception cref="HttpRequestException">May occurs when sending the post request fails</exception>
    /// <exception cref="TaskCanceledException">May occurs when sending the post request fails</exception>
    /// <returns>The parsed Type T</returns>
    public async Task<T> PostBodyAndParseAsync<T>(
        string uri,
        object body,
        (string key, string value)[]? headers = null,
        CancellationToken cancellationToken = default)
    {
        // Send HTTP request
        HttpResponseMessage httpResponse = await PostBodyAsync(uri, body, headers, cancellationToken)
            .ConfigureAwait(false);
        // Parse HTTP response data
        string httpResponseData = await httpResponse.Content.ReadAsStringAsync(cancellationToken)
            .ConfigureAwait(false);

        // Check for exception
        if (!httpResponse.IsSuccessStatusCode)
            throw AuthenticationException.FromResponseData(httpResponseData);

        // Parse as Type T and return
        return JsonHelper.Deserialize<T>(httpResponseData);
    }
}