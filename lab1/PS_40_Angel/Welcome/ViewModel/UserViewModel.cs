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
    
    public User GetUserDetailsByRole(string roleInput)
    {
        if (!userRoleCheck(roleInput))
        {
            throw new ArgumentException("No such user found.");
        }
        return user;
    }
    
    private bool userRoleCheck(String roleInput)
    {
        return roleInput.Equals(user.UserRole.ToString().ToLower());
    }
}