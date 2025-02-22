using WelcomeExtended.Data;
using WelcomeExtended.Helpers;

namespace WelcomeExtended.Others;

public static class Menu
{
    private static UserData _userData = new UserData();

    public static void DisplayMenu()
    {
        while (true)
        {
            Handler();
        }
    }

    private static void Handler()
    {
        DisplayOptions();
        string choice = UserChoice();
        switch (choice)
        {
            case "1":
                UserHelper.DisplayAllUsers(_userData);
                break;
            case "2":
                UserHelper.AddUser(_userData);
                break;
            case "3":
                UserHelper.DeleteUser(_userData);
                break;
            case "4":
                Console.WriteLine("Exiting program...");
                Environment.Exit(0);
                break;
            default:
                Console.WriteLine("Invalid choice. Try again.");
                break;
        }
    }

    private static void DisplayOptions()
    {
        Console.WriteLine("Options:");
        Console.WriteLine("1.Get all users");
        Console.WriteLine("2.Add new user");
        Console.WriteLine("3.Delete user");
        Console.WriteLine("4.Exit");
    }
    private static string UserChoice()
    {
        Console.Write("Choice: ");
        return Console.ReadLine();
    }
}