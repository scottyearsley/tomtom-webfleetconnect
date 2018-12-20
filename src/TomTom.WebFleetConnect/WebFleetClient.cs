using System;
using System.Net.Http;
using TomTom.WebFleetConnect.Models;

namespace TomTom.WebFleetConnect
{
    public class WebFleetClient
    {
        /// <summary>
        /// Creates a new instance of the WebFleet client wrapper.
        /// </summary>
        /// <param name="account">The account name.</param>
        /// <param name="username">The username.</param>
        /// <param name="password">The password.</param>
        /// <param name="apiKey">The API key.</param>
        /// <param name="httpClient"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public WebFleetClient(string account, string username, string password, string apiKey, 
            IWebFleetHttpClient httpClient = null)
        {
            if (string.IsNullOrWhiteSpace(account))
            {
                throw new ArgumentNullException(nameof(account));
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

            httpClient = httpClient ?? new WebFleetHttpClient(new HttpClient
                {
                    BaseAddress = ApiUrl.Root
                }, 
                new ApiSettings(account, username, password, apiKey)
            );

            Users = new UserManagementOperations(httpClient);
        }
        
        /// <summary>
        /// User management operations.
        /// </summary>
        public UserManagementOperations Users { get; }
    }
}