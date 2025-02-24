using System.Windows;

namespace WpfExample;

public partial class NamesWindow : Window
{
    public NamesWindow ()
    {
        InitializeComponent();
        DataContext = new NamesList();
    }
}
