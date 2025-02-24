using System.Windows.Input;

namespace WpfExample;

public class RemoveCommand : ICommand
{
    public bool CanExecute(object? parameter)
    {
        return true;
    }

    public void Execute(object? parameter)
    {
        if (parameter is NamesList nameList && nameList.SelectedName != null)
        {
            nameList.Names.Remove(nameList.SelectedName);
            nameList.SelectedName = null;
        }
    }

    public event EventHandler? CanExecuteChanged;
}