namespace TomTom.WebFleetConnect.Models
{
    public class ApiSettings
    {
        public readonly string Account;
        public readonly string Username;
        public readonly string Password;
        public readonly string ApiKey;

        public ApiSettings(string account, string username, string password, string apiKey)
        {
            Account = account;
            Username = username;
            Password = password;
            ApiKey = apiKey;
        }
    }
}