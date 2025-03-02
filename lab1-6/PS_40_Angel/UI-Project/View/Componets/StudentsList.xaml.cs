using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using DataLayer.Database;
using Welcome.Model;

namespace UI_Project.View.Components;
public partial class StudentsList : UserControl
{
    public StudentsList()
    {
        InitializeComponent();
    }
    private void TestButton_Click(object sender, RoutedEventArgs e)
    {
        if (studentsListBox.ItemsSource is ObservableCollection<User> students)
        {
            MessageBox.Show($"Number of students: {students.Count}");
        }
        else
        {
            MessageBox.Show("No data bound to studentsListBox.");
        }
    }
}