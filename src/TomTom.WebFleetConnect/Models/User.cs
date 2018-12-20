using System;
using Newtonsoft.Json;

namespace TomTom.WebFleetConnect.Models
{
    public class User
    {
        [JsonProperty("username")]
        public string Username { get; set; }

        [JsonProperty("realname")]
        public string RealName { get; set; }

        [JsonProperty("company")]
        public string Company { get; set; }

        [JsonProperty("lastlogin")]
        public DateTime LastLogin { get; set; }

        [JsonProperty("profile")]
        public string Profile { get; set; }

        [JsonProperty("profilename")]
        public string ProfileName { get; set; }

        [JsonProperty("useruid")]
        public string UserUid { get; set; }

        [JsonProperty("interfacestyle")]
        public string InterfaceStyle { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }
    }
}