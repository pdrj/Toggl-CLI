using System;
using System.Net.Http;

namespace TogglCmdLine.Network
{
    public sealed class ApiClient
    {
        private static readonly Lazy<HttpClientHandler> lazyHandler =
            new Lazy<HttpClientHandler>
            (() => new HttpClientHandler
                {
                    ServerCertificateCustomValidationCallback = (message, certificate2, arg3, arg4) => true
                } // toggl.space has some cert issues
            );

        private static readonly Lazy<HttpClient> lazyClient =
            new Lazy<HttpClient>
                (() => new HttpClient(lazyHandler.Value));

        public static HttpClient Instance => lazyClient.Value;

        private ApiClient()
        {
        }
    }
}