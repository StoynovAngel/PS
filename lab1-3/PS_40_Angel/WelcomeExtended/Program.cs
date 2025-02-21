using Welcome.Model;
using Welcome.Others;
using Welcome.View;
using Welcome.ViewModel;
using WelcomeExtended.Auth;
using WelcomeExtended.Data;
using WelcomeExtended.Helpers;
using WelcomeExtended.Loggers;
using WelcomeExtended.Others;

namespace WelcomeExtended;

class Program
{
    static void Main(string[] args)
    {

        UserData userData = new UserData();
        User user = new User("Angel Stoynov", "testova2323", "testova@gmail.com");
        User student = new User("Student", "123", "student@gmail.com", UserRolesEnum.STUDENT);
        User teacher = new User("Teacher", "1234", "teacher@gmail.com", UserRolesEnum.PROFESSOR);
        User admin = new User("Admin", "12345", "admin@gmail.com", UserRolesEnum.ADMIN);
        userData.AddUser(user);
        userData.AddUser(student);
        userData.AddUser(teacher);
        userData.AddUser(admin);
        
        Console.WriteLine(Authentication.Login(userData));
    }
}