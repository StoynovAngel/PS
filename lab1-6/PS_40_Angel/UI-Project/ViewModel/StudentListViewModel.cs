using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using DataLayer.Database;
using Welcome.Model;

namespace UI_Project.ViewModel;

public class StudentsListViewModel : INotifyPropertyChanged
{
    private ObservableCollection<User> _students;
    public event PropertyChangedEventHandler PropertyChanged;

    public ObservableCollection<User> Students
    {
        get => _students;
        set
        {
            _students = value;
            OnPropertyChanged(nameof(Students));
        }
    }

    public ICommand LoadStudentsCommand { get; }

    public StudentsListViewModel()
    {
        Students = new ObservableCollection<User>();
        LoadStudentsCommand = new RelayCommand(LoadStudents);
    }

    private void LoadStudents(object parameter)
    {
        using (var context = new DatabaseContext())
        {
            var records = context.Users.ToList();

            Students.Clear();
            foreach (var user in records)
            {
                Console.WriteLine($"Adding user: {user.Name}");
                Students.Add(user);
            }
        }
    }

    protected void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}