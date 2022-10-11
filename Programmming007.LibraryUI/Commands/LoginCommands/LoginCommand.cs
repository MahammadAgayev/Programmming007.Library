using Programming007.LibraryCore;
using Programming007.LibraryCore.Domain.Entities;
using Programmming007.LibraryUI.Utils;
using Programmming007.LibraryUI.ViewModels;
using Programmming007.LibraryUI.Windows;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Programmming007.LibraryUI.Commands.LoginCommands
{
    public class LoginCommand : ICommand
    {
        private readonly LoginWindowViewModel _viewModel;

        public LoginCommand(LoginWindowViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            User user = Kernel.DB.UserRepository.Get(_viewModel.LoginModel.Username);

            if (user == null)
            {
                _viewModel.IsLoginFailed = Visibility.Visible;
                return;
            }

            string password = ((PasswordBox)parameter).Password;
            string hashedPassword = SecurityUtil.GetHashString(password);

            if (user.PasswordHash != hashedPassword)
            {
                _viewModel.IsLoginFailed = Visibility.Visible;
                return;
            }

            //TODO: open main page logined

            var mainWindow = new MainWindow();
            var viewModel = new MainWindowViewModel();

            viewModel.Window = mainWindow;
            viewModel.Grid = mainWindow.GridCenter;

            mainWindow.DataContext = viewModel;

            mainWindow.Show();

            _viewModel.Window.Close();
        }
    }
}
