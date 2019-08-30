using System.Net.Http;
using System.Net.Http.Headers;

namespace TogglCmdLine.Network
{
    public static class AuthorizedRequestBuilder
    {
        public static HttpRequestMessage CreateRequest(Credentials credentials, string endPoint, HttpMethod method)
        {
            var requestMessage = new HttpRequestMessage(method, endPoint);
            requestMessage.Headers.Authorization = new AuthenticationHeaderValue("Basic", credentials.Header.Value);

            return requestMessage;
        }
    }
}