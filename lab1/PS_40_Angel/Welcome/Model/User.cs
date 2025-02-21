using System.Buffers.Text;
using Welcome.Others;

namespace Welcome.Model;

public class User
{
    private string names;
    private string password;
    private UserRolesEnum _userRole;
    private string email;
    private const int SHIFT_OPERATION = 2;

    public string Name { get; set; }
    
    public UserRolesEnum UserRole { get; set; }

    public string Email { get; set; }

    public string Password
    {
        get {return decryptPassword();}
        set { password = encryptPassword(value); }
    }
    
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
        Console.WriteLine(new string(chars));
        for (int i = 0; i < chars.Length; i++)
        {
            chars[i] = (char)(chars[i] - SHIFT_OPERATION);
        }
        Console.WriteLine(new string(chars));
        return new string(chars);
    }
}