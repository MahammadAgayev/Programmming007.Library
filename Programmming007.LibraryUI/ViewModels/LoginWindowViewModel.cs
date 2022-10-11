using Programmming007.LibraryUI.Commands.LoginCommands;
using Programmming007.LibraryUI.Models.LoginModels;
using System.Windows;
using System.Windows.Input;

namespace Programmming007.LibraryUI.ViewModels
{
    public class LoginWindowViewModel : BaseWindowViewModel
    {
        public LoginWindowViewModel()
        {
            Login = new LoginCommand(this);
        }

        public LoginModel LoginModel { get; set; } = new LoginModel();
        public ICommand Login { get; set; }


        private Visibility isLoginFailed = Visibility.Hidden;
        public Visibility IsLoginFailed
        {
            get
            {
                return isLoginFailed;
            }
            set
            {
                isLoginFailed = value;
                OnPropertyChanged("IsLoginFailed");
            }
        }
    }
}