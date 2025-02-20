using Welcome.Model;
using Welcome.Others;
using Welcome.View;
using Welcome.ViewModel;

namespace Welcome;

class Program
{
    static void Main(string[] args)
    {
        User user = new User();
        user.Name = "Angel Stoynov";
        user.UserRole = UserRolesEnum.INSPECTOR;
        user.Email = "random@gmail.com";
        UserViewModel userViewModel = new UserViewModel(user);
        UserView userView = new UserView(userViewModel);
        userView.DisplayUserByRole("inspector");
    }
}