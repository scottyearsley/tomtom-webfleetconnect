using System;
using System.Net.Http;

namespace TomTom.WebFleetConnect
{
    public class WebFleetClient
    {
        private readonly string _accountName;
        private readonly string _username;
        private readonly string _password;
        private readonly string _apiKey;

        /// <summary>
        /// Creates a new instance of the WebFleet client wrapper.
        /// </summary>
        /// <param name="accountName">The account name.</param>
        /// <param name="username">The username.</param>
        /// <param name="password">The password.</param>
        /// <param name="apiKey">The API key.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public WebFleetClient(string accountName, string username, string password, string apiKey)
        {
            _accountName = accountName;
            _username = username;
            _password = password;
            _apiKey = apiKey;

            if (string.IsNullOrWhiteSpace(accountName))
            {
                throw new ArgumentNullException(nameof(accountName));
            }
            
            if (string.IsNullOrWhiteSpace(username))
            {
                throw new ArgumentNullException(nameof(username));
            }
         
            if (string.IsNullOrWhiteSpace(password))
            {
                throw new ArgumentNullException(nameof(password));
            }
            
            if (string.IsNullOrWhiteSpace(apiKey))
            {
                throw new ArgumentNullException(nameof(apiKey));
            }

            var client = new HttpClient();
            Users = new UserManagementOperations(client);
        }
        
        /// <summary>
        /// User management operations.
        /// </summary>
        public UserManagementOperations Users { get; }
    }
}