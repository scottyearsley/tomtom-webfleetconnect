using System.Collections.Generic;
using System.Threading.Tasks;
using TomTom.WebFleetConnect.Models;

namespace TomTom.WebFleetConnect.Operations
{
    public class UserManagement
    {
        private readonly IWebFleetHttpClient _httpClient;

        internal UserManagement(IWebFleetHttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        /// <summary>
        /// Returns a list of all existing users within the account along with the last recorded login time.
        /// </summary>
        /// <returns></returns>
        public async Task<List<User>> ShowUsers(UserFilter userFilter = null)
        {
            var parameters = new ApiParameters(OperationParameters.UserManagement.ShowUsers, userFilter);
            
            return await _httpClient.Get<List<User>>("showUsers", parameters);
        }
    }
}