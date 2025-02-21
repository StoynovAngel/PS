using Welcome.Model;
using WelcomeExtended.Data;
using WelcomeExtended.Helpers;
using WelcomeExtended.Loggers;

namespace WelcomeExtended.Auth;

public static class Authentication
{
    public static User? Login(this UserData userData)
    {
        return loginInput(userData);
    }

    private static User? loginInput(UserData userData)
    {
        Console.Write("Write a name: ");
        string name = Console.ReadLine();
        Console.Write("Write a password: ");
        string password = Console.ReadLine();
        UserHelper.ValidateCredentials(userData, name, password);

        User? user = UserHelper.GetUser(userData, name, password);
        
        if (user != null)
        {
            Logger.LoginActivity(user, "Logged successfully.");
            return user;
        }
        Logger.LoginActivity("Logged UNsuccessfully.");
        return null;
    }
}