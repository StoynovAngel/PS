using Welcome.Model;
using Welcome.Others;
using WelcomeExtended.Loggers;

namespace WelcomeExtended.Data;

public class UserData
{
    private List<User> _users;
    private int _nextId;

    public UserData()
    {
        _users = new List<User>();
        _nextId = 0;
    }

    public void AddUser(User user)
    {
        user.Id = _nextId++;
        _users.Add(user);
    }

    public void DeleteUser(User user)
    {
        _users.Remove(user);
    }

    public bool ValidateUser(string name, string password)
    {
        try
        {
            foreach (var user in _users)
            {
                if (user.Name.Equals(name) && user.Password.Equals(password)) return true;
            }
            throw new ArgumentException();
        }
        catch (ArgumentException e)
        {
            Logger.LogToFile("Incorrect name or password", e);
        }

        return false;
    }

    public bool ValidateUserLambda(string name, string password)
    {
        return _users.FirstOrDefault(user => user.Name.Equals(name) && user.Password.Equals(password)) != null ? true : false;
    }

    public bool ValidateUserLinq(string name, string password)
    {
        var ret = from user in _users where user.Name.Equals(name) && user.Password.Equals(password) select user.Id;
        return ret != null ? true : false;
    }

    public User? getUser(string name, string password)
    {
        var ret = from user in _users
            where user.Name.Equals(name) && user.Password.Equals(password)
            select user;

        User? foundUser = ret.FirstOrDefault();

        if (foundUser == null)
        {
            Logger.LogToFile($"No such user found: {name}");
            Console.WriteLine("No such user found.");
            return null;
        }

        return foundUser;
    }

    public void setActive(string name, DateTime dateTime)
    {
        var user = GetUserByName(name);
        user.Expires = dateTime;
    }

    public void AssignUserRole(string name, UserRolesEnum role)
    {
        var user = GetUserByName(name);
        user.UserRole = role;
    }

    private User GetUserByName(string name)
    {
        var user = _users.FirstOrDefault(u => u.Name == name);
        CheckIfUserExists(user);
        return user;
    }
    private static void CheckIfUserExists(User user)
    {
        if (user == null) throw new ArgumentException("User with such name does not exists: " + user);
    }
}