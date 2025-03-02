using System.ComponentModel;
using System.Windows.Input;

namespace UI_Project.ViewModel
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private string _statusMessage;

        public event PropertyChangedEventHandler PropertyChanged;

        public string StatusMessage
        {
            get => _statusMessage;
            set
            {
                _statusMessage = value;
                OnPropertyChanged(nameof(StatusMessage));
            }
        }

        public ICommand UpdateStatusCommand { get; }

        public MainWindowViewModel()
        {
            UpdateStatusCommand = new RelayCommand(UpdateStatus, CanUpdateStatus);
        }

        private void UpdateStatus(object parameter)
        {
            StatusMessage = "Status updated at " + DateTime.Now;
        }

        private bool CanUpdateStatus(object parameter)
        {
            return true;
        }

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}