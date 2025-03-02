using Welcome.Model;
using Welcome.Others;
using Welcome.View;
using Welcome.ViewModel;

namespace Welcome;

class Program
{
    static void Main(string[] args)
    {
        User user = new User
        {
            UserRole = UserRolesEnum.STUDENT,
            Email = "angel@gmail.com",
            Name = "Angel",
            Password = "jsdfjsdfh",
        };
        Console.WriteLine(user.ToString());
        UserViewModel userViewModel = new UserViewModel(user);
        UserView userView = new UserView(userViewModel);
        userView.DisplayUserByRole("student");
        userView.DisplayForm();
    }
}