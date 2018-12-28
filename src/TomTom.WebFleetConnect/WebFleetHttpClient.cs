using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using TomTom.WebFleetConnect.Models;

namespace TomTom.WebFleetConnect
{
    internal class WebFleetHttpClient: IWebFleetHttpClient
    {
        private readonly HttpClient _httpClient;
        private readonly ApiSettings _apiSettings;

        public WebFleetHttpClient(HttpClient httpClient, ApiSettings apiSettings)
        {
            _httpClient = httpClient;
            _apiSettings = apiSettings;
        }
        
        public async Task<T> Get<T>(string action, ApiParameters parameters)
        {
            var apiParams = ApiUrl.Create(_apiSettings, action, parameters);
            var response = await _httpClient.GetAsync(apiParams);
            return await HandleResponse<T>(response);
        }

        public async Task Get(string action, ApiParameters parameters = null)
        {
            var apiParams = ApiUrl.Create(_apiSettings, action, parameters);
            var response = await _httpClient.GetAsync(apiParams);
            await HandleResponse(response);
        }

        private static async Task<T> HandleResponse<T>(HttpResponseMessage response)
        {
            var content = await response.Content.ReadAsStringAsync();
            var error = JsonConvert.DeserializeObject<ErrorResponse>(content);
            if (error.IsInitialized)
            {
                // TODO: Create specific exception type
                throw new Exception(error.Message);
            }
            return JsonConvert.DeserializeObject<T>(content);
        }

        private static async Task HandleResponse(HttpResponseMessage response)
        {
            var content = await response.Content.ReadAsStringAsync();
            var error = JsonConvert.DeserializeObject<ErrorResponse>(content);
            if (error.IsInitialized)
            {
                // TODO: Create specific exception type
                throw new Exception(error.Message);
            }
        }
    }
}