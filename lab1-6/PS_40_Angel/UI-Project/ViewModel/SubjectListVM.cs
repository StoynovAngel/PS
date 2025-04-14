using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using DataLayer.Database;
using Welcome.Model;

namespace UI_Project.ViewModel;

public class SubjectListVM : INotifyPropertyChanged
{
    private ObservableCollection<Subject> subjects;
    public event PropertyChangedEventHandler? PropertyChanged;

    public ObservableCollection<Subject> Subjects
    {
        get => subjects;
        set
        {
            subjects = value;
            OnPropertyChanged(nameof(Subjects));
        }
    }
    
    public ICommand LoadSubjectsCommand { get; }

    public SubjectListVM()
    {
        Subjects = new ObservableCollection<Subject>();
        LoadSubjectsCommand = new RelayCommand(LoadSubjects);
    }

    private void LoadSubjects(object parameter)
    {
        using (var context = new DatabaseContext())
        {
            var records = context.Subjects.ToList();
            Subjects.Clear();
            foreach (var record in records)
            {
                Console.WriteLine($"Adding subject: {record.Name}");
                Subjects.Add(record);
            }
        }
    }
    
    protected void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    protected bool SetField<T>(ref T field, T value, [CallerMemberName] string? propertyName = null)
    {
        if (EqualityComparer<T>.Default.Equals(field, value)) return false;
        field = value;
        OnPropertyChanged(propertyName);
        return true;
    }
}