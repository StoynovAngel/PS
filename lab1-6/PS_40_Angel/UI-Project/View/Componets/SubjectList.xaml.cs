using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using Welcome.Model;

namespace UI_Project.View.Components;

public partial class SubjectList : UserControl
{
    public SubjectList()
    {
        InitializeComponent();
    }
    
    private void Counter_Button_Click(object sender, RoutedEventArgs e)
    {
        if (subjectBox.ItemsSource is ObservableCollection<Subject> subjects)
        {
            MessageBox.Show("Number of subjects is " + subjects.Count);
        }
        else
        {
            MessageBox.Show("Nqma nikoi brato");
        }
    }

    private void Counter_2024(object sender, RoutedEventArgs e)
    {
        if (subjectBox.ItemsSource is ObservableCollection<Subject> subjects)
        {
            foreach (Subject subject in subjects)
            {
                if (subject.Year.Equals("2024"))
                {
                    MessageBox.Show( subject.ToString());
                }
            }
        }
    }
}