using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TomTom.WebFleetConnect.Models
{
    public class ApiParameters: Dictionary<string, string>
    {
        public string ToQuery()
        {
            return string.Join("&", this.Select(kvp => $"{kvp.Key}={HttpUtility.UrlEncode(kvp.Value)}"));
        }
    }
}