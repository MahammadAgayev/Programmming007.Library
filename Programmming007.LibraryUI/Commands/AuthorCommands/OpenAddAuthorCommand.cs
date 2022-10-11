using Programmming007.LibraryUI.ViewModels;
using Programmming007.LibraryUI.Windows;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace Programmming007.LibraryUI.Commands.AuthorCommands
{
    public class OpenAddAuthorCommand : ICommand
    {
        private readonly AuthorUserControlViewModel _viewModel;

        public OpenAddAuthorCommand(AuthorUserControlViewModel viewModel)
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

            window.ShowDialog();

            if (viewModel.AuthorModel.Id != 0)
                _viewModel.Authors.Add(viewModel.AuthorModel);
        }
    }
}
