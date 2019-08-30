using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Mime;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using TogglCmdLine.Logging;
using TogglCmdLine.Model;
using TogglCmdLine.SharedTypes;

namespace TogglCmdLine.Network.Requests
{
    public class BaseApiCall
    {
        private readonly string BASE_API_URL = "https://toggl.space/api/v9/";

        protected async Task<T> makeRequest<T>(string endpoint, HttpMethod httpMethod, Email email, Password password, ManualResetEvent manualResetEvent = null, object additionalData = null)
        {
            ConsoleLogger.Log($"make request to {endpoint} with {httpMethod}");
            var credentials = Credentials.WithPassword(email, password);
            var requestMessage = AuthorizedRequestBuilder.CreateRequest(
                credentials, $"{BASE_API_URL}{endpoint}", httpMethod);

            if (additionalData != null)
            {
                var asJson = JsonConvert.SerializeObject(additionalData, Formatting.None, new JsonSerializerSettings()
                {
//                    NullValueHandling = NullValueHandling.Ignore,
                    DateFormatString = @"yyyy-MM-dd\THH:mm:ssK",
                    ContractResolver = new DefaultContractResolver()
                    {
                        NamingStrategy = new SnakeCaseNamingStrategy()
                    }

                });
                ConsoleLogger.Log($"as json {asJson}");
                var requestData = new StringContent(
                    asJson,
                    Encoding.UTF8,
                    "application/json"
                );
                
                
                requestMessage.Content = requestData;
            }

            var response = await ApiClient.Instance.SendAsync(requestMessage);
            
            ConsoleLogger.Log($"response status code {response.StatusCode}");
            
            if (!response.IsSuccessStatusCode)
            {
                ConsoleLogger.Log("ERR status code");
                return default;
            }
            
            var data = await response.Content.ReadAsStringAsync();
            ConsoleLogger.Log($" data {data}");

            var deserialized = JsonConvert.DeserializeObject<T>(data);
            return deserialized;
            
        }
    }
}