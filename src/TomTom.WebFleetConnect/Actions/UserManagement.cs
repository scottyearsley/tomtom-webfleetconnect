using System.Collections.Generic;
using System.Threading.Tasks;
using TomTom.WebFleetConnect.Models;

namespace TomTom.WebFleetConnect.Actions
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

        /// <summary>
        /// Used to change the password of your own user account.
        /// </summary>
        /// <param name="oldPassword">The current password of the user account.</param>
        /// <param name="newPassword">The new password.</param>
        public async Task ChangePassword(string oldPassword, string newPassword)
        {
            var parameters = new ApiParameters(OperationParameters.UserManagement.ChangePassword, 
                new { oldPassword, newPassword });
            
            await _httpClient.Get(nameof(UserManagementOperations.ChangePassword), parameters);
        }
    }
}