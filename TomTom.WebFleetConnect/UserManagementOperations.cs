using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using TomTom.WebFleetConnect.Models;

namespace TomTom.WebFleetConnect
{
    public class UserManagementOperations
    {
        private readonly IWebFleetHttpClient _httpClient;

        internal UserManagementOperations(IWebFleetHttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<User>> ShowUsers()
        {
            return _httpClient
        }
    }
}