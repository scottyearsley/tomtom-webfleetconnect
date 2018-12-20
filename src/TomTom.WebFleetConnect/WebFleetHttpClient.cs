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
            var content = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<T>(content);
        }
    }
}