using System;
using TomTom.WebFleetConnect.Models;

namespace TomTom.WebFleetConnect
{
    public static class ApiUrl
    {
        public static readonly Uri Root = new Uri("https://csv.telematics.tomtom.com/extern");
        
        public static string Create(ApiSettings settings, string action)
        {
            return $"?lang=en&account={settings.Account}&username={settings.Username}" +
                   $"&password={settings.Password}&apikey={settings.ApiKey}&outputformat=json&action={action}";
;
        }
    }
}