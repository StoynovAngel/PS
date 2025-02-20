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
    }

    public void DisplayUserByRole(String role)
    {
        Console.WriteLine(viewModel.GetUserDetailsByRole(role));
    }
}