using System.ComponentModel;
using System.Windows.Controls;

namespace Programmming007.LibraryUI.ViewModels
{
    public abstract class BaseUserControlViewModel : INotifyPropertyChanged
    {
        public UserControl UserControl { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propName)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
    }
}
