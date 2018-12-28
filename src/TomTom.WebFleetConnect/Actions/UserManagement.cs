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
        public async Task<List<User>> ShowUsersAsync(UserFilter userFilter = null)
        {
            var parameters = new ApiParameters(OperationParameters.UserManagement.ShowUsers, userFilter);
            
            return await _httpClient.Get<List<User>>("showUsers", parameters);
        }

        /// <summary>
        /// Returns a list of all existing users within the account along with the last recorded login time.
        /// </summary>
        /// <returns></returns>
        public List<User> ShowUsers(UserFilter userFilter = null)
        {
            return ShowUsersAsync(userFilter).Result;
        }

        /// <summary>
        /// Used to change the password of the current user account.
        /// </summary>
        /// <param name="oldPassword">The current password of the user account.</param>
        /// <param name="newPassword">The new password.</param>
        public async Task ChangePasswordAsync(string oldPassword, string newPassword)
        {
            var parameters = new ApiParameters(OperationParameters.UserManagement.ChangePassword, 
                new { oldPassword, newPassword });
            
            await _httpClient.Get(nameof(UserManagementOperations.ChangePassword), parameters);
        }
    }
}