using Programmming007.LibraryUI.Utils;
using Programmming007.LibraryUI.ViewModels;
using Programmming007.LibraryUI.Windows;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace Programmming007.LibraryUI.Commands.DbConfigurationCommands
{
    public class SaveConfigurationCommand : ICommand
    {
        private readonly DbConfigurationViewModel _viewModel;
        private readonly ConfigHelper _configHelper;

        public SaveConfigurationCommand(DbConfigurationViewModel viewModel)
        {
            _viewModel = viewModel;
            _configHelper = new ConfigHelper();
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            _configHelper.SaveToFile(_viewModel.Config);

            LoadingWindow window = new LoadingWindow();
            window.Show();

            _viewModel.Window.Close();
        }
    }
}
