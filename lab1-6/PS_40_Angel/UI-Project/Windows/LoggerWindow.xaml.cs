using System.Windows;
using System.Windows.Input;
using Microsoft.Extensions.Logging;

namespace UI_Project.Windows;

public partial class LoggerWindow : Window
{
    public LoggerWindow()
    {
        InitializeComponent();
        LoggerDataGrid.ItemsSource = Logger.GetEntries();
    }
    
    private void LoggerDataGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
    {
        if (LoggerDataGrid.SelectedItem is LoggerEntry entry)
        {
            string formattedMessage = $"Date: {entry.Date}\n Event: {entry.EventDetails}";
            MessageBox.Show(formattedMessage, "Details", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}