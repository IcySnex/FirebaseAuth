using System.Net;
using System.Text.Json.Serialization;

namespace FirebaseAuth.Responses;

public class ErrorResponse
{
    [JsonPropertyName("error")]
    public ErrorResponseError Error { get; set; } = new();
}

public class ErrorResponseError
{
    [JsonPropertyName("code")]
    public HttpStatusCode Code { get; set; } = HttpStatusCode.BadRequest;

    [JsonPropertyName("message")]
    public string Message { get; set; } = "UNDEFINDED";
}