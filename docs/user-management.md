# User Management

* [ShowUsers(UserFilter filter = null)](#show-users)
* [ShowUsersAsync(UserFilter filter = null)](#show-users-asynchronous)
* [ChangePassword(string oldPassword, string newPassword)](#change-password)
* [ChangePasswordAsync(string oldPassword, string newPassword)](#change-password-asynchronous)

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

## Show Users (asynchronous)

Returns all users for an account without any filtering.

### Syntax

``` cs
Task<List<User>> ShowUsersAsync(UserFilter = null)
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
Task<List<User>> users = await client.UserManagement.ShowUsersAsync();

// List users for a specific company
Task<List<User>> users = await client.UserManagement.ShowUsersAsync(
    new UserFilter
    {
        Company = "[Company]"
    }
);
```

---

## Change Password

Used to change the password of the current user account.

### Syntax

``` cs
void ChangePassword(string oldPassword, string newPassword)
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

---

## Change Password (asynchronous)

Used to change the password of the current user account.

### Syntax

``` cs
Task ChangePassword(string oldPassword, string newPassword)
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

await client.UserManagement.ChangePasswordAsync("[oldPassword]", "[newPassword]");
```