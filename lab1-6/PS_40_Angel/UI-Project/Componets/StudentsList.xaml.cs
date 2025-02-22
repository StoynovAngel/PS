using System.Windows.Controls;
using DataLayer.Database;

namespace UI_Project.Componets;

public partial class StudentsList : UserControl
{
    public StudentsList()
    {
        InitializeComponent();
        using (var context = new DatabaseContext())
        {
            var records = context.Users.ToList();
            students.DataContext = records;
        }
    }
}