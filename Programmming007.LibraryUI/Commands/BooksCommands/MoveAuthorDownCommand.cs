using Programmming007.LibraryUI.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace Programmming007.LibraryUI.Commands.BooksCommands
{
    public class MoveAuthorDownCommand : ICommand
    {
        private readonly SaveBookWindowWiewModel _viewModel;

        public MoveAuthorDownCommand(SaveBookWindowWiewModel viewModel)
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
            _viewModel.BookModel.SelectedAuthors.Add(_viewModel.SelectedAuthorToDown);
            _viewModel.Authors.Remove(_viewModel.SelectedAuthorToDown);
        }
    }
}
