using System.Buffers.Text;
using Welcome.Others;

namespace Welcome.Model;

public class User
{
    private string name;
    private string password;
    private UserRolesEnum userRole;
    private string email;
    private const int SHIFT_OPERATION = 2;
    
    public User(string name, string password, string email, UserRolesEnum userRole = UserRolesEnum.ANONYMOUS)
    {
        this.name = name;
        this.password = encryptPassword(password);
        this.email = email;
        this.userRole = userRole;
    }

    public string Password
    {
        get {return decryptPassword();}
        set { password = encryptPassword(value); }
    }
    
    public string Name { get { return name; } set { name = value; } }
    public UserRolesEnum UserRole { get { return userRole; } set { userRole = value; } }
    public string Email { get { return email; } set { email = value; } }
    
    public override string ToString()
    {
        return $"User: {Name}, Password: {Password}, Role: {UserRole}, Email: {Email}";
    }

    private string encryptPassword(string password)
    {
        char[] chars = password.ToCharArray();

        for (int i = 0; i < chars.Length; i++)
        {
            chars[i] = (char)(chars[i] + SHIFT_OPERATION);
        }
        return new string(chars);
    }

    private string decryptPassword()
    {
        char[] chars = password.ToCharArray();
        for (int i = 0; i < chars.Length; i++)
        {
            chars[i] = (char)(chars[i] - SHIFT_OPERATION);
        }
        return new string(chars);
    }
}