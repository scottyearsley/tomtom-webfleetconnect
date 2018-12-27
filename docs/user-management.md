# User Management

* [ShowUsers(UserFilter filter = null)](#show-users)

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
// List users with no filtering
List<User> users = client.Users.ShowUsers();

// List users for a specific company
List<User> companyUsers = client.Users.ShowUsers(
    new UserFilter
    {
        Company = "[Company]"
    }
);
```