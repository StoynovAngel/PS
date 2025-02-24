using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using EazyMVVM;

namespace EasyMVVM
{
    public class MainWindowVM : INotifyPropertyChanged
    {
        private ObservableCollection<string> _BackingProperty;
        
        public ObservableCollection<string> BoundProperty
        {
            get { return _BackingProperty; }
            set
            {
                _BackingProperty = value;
                PropChanged(nameof(BoundProperty));
            }
        }
        
        public MainWindowVM()
        {
            Model m = new Model();
            BoundProperty = m.GetData();
        }
        
        public event PropertyChangedEventHandler PropertyChanged;
        
        public void PropChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}