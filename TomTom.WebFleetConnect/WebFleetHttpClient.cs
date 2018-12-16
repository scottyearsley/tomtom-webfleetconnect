using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace TomTom.WebFleetConnect
{
    public class WebFleetHttpClient: IWebFleetHttpClient
    {
        private readonly HttpClient _httpClient;

        public WebFleetHttpClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        
        public async Task<T> Get<T>(string action, object parameters)
        {
            var response = await _httpClient.GetAsync("");
            var content = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<T>(content);;
        }
    }
}