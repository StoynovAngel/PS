using Welcome.Others;
using Welcome.ViewModel;

namespace Welcome.View;

public class UserView
{
    private UserViewModel viewModel;

    public UserView(UserViewModel viewModel)
    {
        this.viewModel = viewModel;
    }

    public void DisplayForm()
    {
        Console.WriteLine("Welcome!!!");
        Console.WriteLine($"User: {viewModel.Name}");
        Console.WriteLine($"Role: {viewModel.Role}");
        Console.WriteLine($"Email: {viewModel.Email}");
        Console.WriteLine($"Password: {viewModel.Password}");
    }

    public void DisplayUserByRole(String role)
    {
        try
        {
            Console.WriteLine(viewModel.GetUserDetailsByRole(role));
        }
        catch (ArgumentException e)
        {
            Console.WriteLine("Illegal argument: " + e);
        }
    }
    
    public void DisplayError()
    {
        throw new Exception("Unexpected error occured.");
    }
    
    public void DisplayError(String errorMessage)
    {
        throw new Exception(errorMessage);
    }
}