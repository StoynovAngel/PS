using Welcome.Model;
using WelcomeExtended.Data;

namespace WelcomeExtended.Helpers;

public static class UserHelper
{
    public static string ToString(this User user)
    {
        return $"User: {user.Name}, Role: {user.UserRole}, Email: {user.Email}, Expires: {user.Expires}";
    }
    
    public static void ValidateCredentials(this UserData userData, string name, string password)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentException("The name cannot be empty");
        }

        if (string.IsNullOrWhiteSpace(password))
        {
            throw new ArgumentException("The password cannot be empty");
        }
        userData.ValidateUser(name, password);
    }
    
    public static User? GetUser(this UserData userData, string name, string password)
    {
        return userData.getUser(name, password); 
    }

    public static void DisplayAllUsers(this UserData userData)
    {
        userData.displayAllUsers();
    }

    public static void AddUser(this UserData userData)
    {
        userData.addUser();
    }

    public static void DeleteUser(this UserData userData)
    {
        userData.deleteUser();
    }
}