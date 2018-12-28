# User Management

* [ShowUsers(UserFilter filter = null)](#show-users)
* [ChangePassword(string oldPassword, string newPassword)](#change-password)

## Show Users

Returns all users for an account without any filtering.

### Syntax

``` cs
List<User> ShowUsers(UserFilter = null)
{
}
```

### Parameters

*userFilter*
> Type: [UserFilter](models/userfilter.md)  
> User filter configuration

### Examples

``` cs
var client = ... // initialize WebFleetConnectClient instance.

// List users with no filtering
List<User> users = client.Users.ShowUsers();

// List users for a specific company
List<User> companyUsers = client.UserManagement.ShowUsers(
    new UserFilter
    {
        Company = "[Company]"
    }
);
```

---

## Change Password

Returns all users for an account without any filtering.

### Syntax

``` cs
List<User> ShowUsers(UserFilter = null)
{
}
```

### Parameters

*oldPassword*
> Type: `string`  
> The current password of the user account.

*newPassword*
> Type: `string`  
> The new password.

### Example

``` cs
var client = ... // initialize WebFleetConnectClient instance.

client.UserManagement.ChangePassword("[oldPassword]", "[newPassword]");
```