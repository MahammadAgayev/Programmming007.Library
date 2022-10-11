using System.ComponentModel;
using System.Windows;

namespace Programmming007.LibraryUI.ViewModels
{
    public abstract class BaseWindowViewModel : INotifyPropertyChanged
    {
        public Window Window { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
    }
}
