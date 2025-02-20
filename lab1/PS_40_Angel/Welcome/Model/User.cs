using System.Buffers.Text;
using Welcome.Others;

namespace Welcome.Model;

public class User
{
    private string names;
    private string password;
    private UserRolesEnum _userRole;
    private string email;

    public string Name { get; set; }
    
    public UserRolesEnum UserRole { get; set; }

    public string Email { get; set; }
    
    public string Password { get; set; }
    
    public override string ToString()
    {
        return $"User: {Name}, Role: {UserRole}, Email: {Email}";
    }
}