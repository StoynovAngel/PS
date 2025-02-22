using DataLayer.Database;
using DataLayer.Model;
using Microsoft.EntityFrameworkCore;
using Welcome.Model;
using Welcome.Others;

using (var context = new DatabaseContext())
{
    // context.Database.EnsureCreated();
    // context.Add<DatabaseUser>(new DatabaseUser()
    // {
    //     Name = "user",
    //     Password = "password",
    //     Email = "email",
    //     Expires = DateTime.Now,
    //     UserRole = UserRolesEnum.STUDENT
    // });
    // context.SaveChanges();
    // Console.ReadKey();
    var users = context.Users.ToList();

    foreach (var user in users)
    {
        Console.WriteLine($"User: {user.Name}, Role: {user.UserRole}, Email: {user.Email}");
    }

    Console.WriteLine(validUser(users));
}


// По условие в program.cs
string validUser(IEnumerable<User> users)
{
    Console.Write("What is your name: ");
    string name = Console.ReadLine();
    
    Console.Write("What is your password: ");
    string password = Console.ReadLine();
    
    var ret = from user in users
        where user.Name.Equals(name) 
              && user.Password.Equals(password)
        select user;

    return ret.Any() ? "Valid user" : "Incorrect information";
}
