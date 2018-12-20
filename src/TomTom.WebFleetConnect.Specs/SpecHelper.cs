using System;
using System.Net.Http;
using TomTom.WebFleetConnect.Models;

namespace TomTom.WebFleetConnect.Specs
{
    public static class SpecHelper
    {
        private const string Account = "account";
        private const string Username = "username";
        private const string Password = "password";
        private const string ApiKey = "api_key";

        public static Uri CreateUri(string action)
        {
            return new Uri(ApiUrl.Root, 
                ApiUrl.Create(new ApiSettings(Account, Username, Password, ApiKey), action));
        }
        
        public static WebFleetClient CreateClient(HttpMessageHandler handler)
        {
            var client = new HttpClient(handler)
            {
                BaseAddress = ApiUrl.Root
            };

            return new WebFleetClient(Account, Username, Password, ApiKey, 
                new WebFleetHttpClient(client, new ApiSettings(Account, Username, Password, ApiKey)));
        }
    }
}