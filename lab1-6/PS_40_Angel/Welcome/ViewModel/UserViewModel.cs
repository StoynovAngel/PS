using Welcome.Model;
using Welcome.Others;

namespace Welcome.ViewModel;

public class UserViewModel
{
    private User user;

    public UserViewModel(User user)
    {
        this.user = user;
    }

    public string Name
    {
        get { return user.Name; }
        set { user.Name = value; }
    }

    public UserRolesEnum Role
    {
        get { return user.UserRole; }
        set { user.UserRole = value; }
    }
    
    public string Email
    {
        get { return user.Email; }
        set { user.Email = value; }
    }
    
    public string Password
    {
        get { return user.Password; }
        set { user.Password = value; }
    }
    
    public User GetUserDetailsByRole(String role)
    {
        if (!CheckIfUserRoleIsCorrect(role))
        {
            throw new ArgumentException("The role does not match any of the enum");
        }
        return user;
    }

    private bool CheckIfUserRoleIsCorrect(String role)
    {
        return Enum.IsDefined(typeof(UserRolesEnum), role.ToUpper());
    }
}