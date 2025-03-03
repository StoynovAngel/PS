using Welcome.Model;
using Welcome.Others;
using Welcome.View;
using Welcome.ViewModel;
using WelcomeExtended.Auth;
using WelcomeExtended.Data;
using WelcomeExtended.Helpers;
using WelcomeExtended.Loggers;
using WelcomeExtended.Others;

namespace WelcomeExtended;

class Program
{
    static void Main(string[] args)
    {
        Menu.DisplayMenu();
        {
            try
            {
                Console.WriteLine(test(3, 0));
                User user = new User();
                var viewModel = new UserViewModel(user);
                var view = new UserView(viewModel);
                view.DisplayForm();

            }
            catch (Exception e)
            {
                Logger.LogToFile("Exception occured in the user form.");
                var log = new ActionOnError(Delegates.Log);
                log(e.Message);
            }
            finally
            {
                Console.WriteLine("Executed....");
            }

        }
    }
    private static int test(int a, int b)
    {
        return a / b;
    }
}