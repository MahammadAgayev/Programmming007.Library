using Programmming007.LibraryUI.ViewModels;
using System;
using System.Windows.Input;

namespace Programmming007.LibraryUI.Commands.DbConfigurationCommands
{
    public class CancelConfigurationCommand : ICommand
    {
        private readonly DbConfigurationViewModel _viewModel;

        public CancelConfigurationCommand(DbConfigurationViewModel viewModel)
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
            _viewModel.Window.Close();
        }
    }
}
