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

        /// <summary>
        /// Returns a list of all existing users within the account along with the last recorded login time.
        /// </summary>
        /// <returns></returns>
        public async Task<List<User>> ShowUsers(UserFilter userFilter = null)
        {
            var parameters = new ApiParameters();
            if (userFilter != null)
            {
                if (!string.IsNullOrWhiteSpace(userFilter.Username))
                {
                    parameters.Add("username_filter", userFilter.Username);
                }
                if (!string.IsNullOrWhiteSpace(userFilter.RealName))
                {
                    parameters.Add("realname_filter", userFilter.RealName);
                }
                if (!string.IsNullOrWhiteSpace(userFilter.Company))
                {
                    parameters.Add("company_filter", userFilter.Company);
                }
            }
            
            return await _httpClient.Get<List<User>>("showUsers", parameters);
        }
    }
}