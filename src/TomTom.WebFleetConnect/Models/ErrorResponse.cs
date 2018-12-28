using Newtonsoft.Json;

namespace TomTom.WebFleetConnect.Models
{
    public class ErrorResponse
    {
        [JsonProperty("errorCode")]
        public string Code { get; set; }

        [JsonProperty("errorMsg")]
        public string Message { get; set; }

        public bool IsInitialized => Code != null;
    }
}