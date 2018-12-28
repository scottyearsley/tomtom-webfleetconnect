using System.Collections.Generic;
using TomTom.WebFleetConnect.Models;

namespace TomTom.WebFleetConnect.Actions
{
    internal static class OperationParameters
    {
        public static readonly UserManagementOperations UserManagement = new UserManagementOperations(); 
        
        public static ParameterMap Map = new ParameterMap
        {
            { 
                UserManagement.ShowUsers, 
                new List<(string WrapperName, string ConnectName, bool Required)>
                {
                    ( nameof(UserFilter.Company), "company_filter", false ),
                    ( nameof(UserFilter.Username), "company_username", false ),
                    ( nameof(UserFilter.RealName), "company_realname", false ),
                }  
            },
            { 
                UserManagement.ChangePassword, 
                new List<(string WrapperName, string ConnectName, bool Required)>
                {
                    ( "OldPassword", "oldpassword", true ),
                    ( "NewPassword", "newpassword", true ),
                }  
            }
        };
    }

    internal class UserManagementOperations
    {
        public readonly string ShowUsers = "showUsers";
        public readonly string ChangePassword = "changePasswords";
    }

    internal class ParameterMap: Dictionary<string, List<(string WrapperName, string ConnectName, bool Required)>>
    {
    }
}