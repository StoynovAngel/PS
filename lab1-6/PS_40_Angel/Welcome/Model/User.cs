using System.Buffers.Text;
using Welcome.Others;

namespace Welcome.Model;

public class User
{
    private int id;
    private string name;
    private string password;
    private UserRolesEnum userRole;
    private string email;
    private DateTime expires;
    private const int SHIFT_OPERATION = 2;

    public string Password
    {
        get { return password;}
        set { password = encryptPassword(value); }
    }
    
    public virtual int Id { get => id; set => id = value; }
    public string Name { get => name;
        set => name = value;
    }
    public UserRolesEnum UserRole { get { return userRole; } set { userRole = value; } }
    public string Email { get { return email; } set { email = value; } }
    
    public DateTime Expires { get { return expires; } set { expires = value; } }
    
    public override string ToString()
    {
        return $"User: {Name}, Encrypted Password: {Password}, Role: {UserRole}, Email: {Email}";
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

    public string decryptPassword()
    {
        char[] chars = password.ToCharArray();
        for (int i = 0; i < chars.Length; i++)
        {
            chars[i] = (char)(chars[i] - SHIFT_OPERATION);
        }
        return new string(chars);
    }
}