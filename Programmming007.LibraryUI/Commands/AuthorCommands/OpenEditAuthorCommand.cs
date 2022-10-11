using Programmming007.LibraryUI.ViewModels;
using Programmming007.LibraryUI.Windows;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace Programmming007.LibraryUI.Commands.AuthorCommands
{
    public class OpenEditAuthorCommand : ICommand
    {
        private readonly AuthorUserControlViewModel _viewModel;

        public OpenEditAuthorCommand(AuthorUserControlViewModel viewModel)
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
            var window = new SaveAuthorWindow();
            var viewModel = new SaveAuthorWindowViewModel();

            window.DataContext = viewModel;
            viewModel.Window = window;
            viewModel.AuthorModel = _viewModel.SelectedAuthor;

            window.ShowDialog();
        }
    }
}
